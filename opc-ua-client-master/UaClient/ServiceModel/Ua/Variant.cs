﻿// Copyright (c) Converter Systems LLC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Workstation.ServiceModel.Ua
{
    public enum VariantType
    {
        Null,
        Boolean,
        SByte,
        Byte,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        Float,
        Double,
        String,
        DateTime,
        Guid,
        ByteString,
        XmlElement,
        NodeId,
        ExpandedNodeId,
        StatusCode,
        QualifiedName,
        LocalizedText,
        ExtensionObject,
        DataValue,
        Variant,
        DiagnosticInfo,
    }

    public struct Variant
    {
        public static Variant Null = default(Variant);

        private static Dictionary<Type, VariantType> typeMap = new Dictionary<Type, VariantType>()
        {
            [typeof(bool)] = VariantType.Boolean,
            [typeof(sbyte)] = VariantType.SByte,
            [typeof(byte)] = VariantType.Byte,
            [typeof(short)] = VariantType.Int16,
            [typeof(ushort)] = VariantType.UInt16,
            [typeof(int)] = VariantType.Int32,
            [typeof(uint)] = VariantType.UInt32,
            [typeof(long)] = VariantType.Int64,
            [typeof(ulong)] = VariantType.UInt64,
            [typeof(float)] = VariantType.Float,
            [typeof(double)] = VariantType.Double,
            [typeof(string)] = VariantType.String,
            [typeof(DateTime)] = VariantType.DateTime,
            [typeof(Guid)] = VariantType.Guid,
            [typeof(byte[])] = VariantType.ByteString,
            [typeof(XElement)] = VariantType.XmlElement,
            [typeof(NodeId)] = VariantType.NodeId,
            [typeof(ExpandedNodeId)] = VariantType.ExpandedNodeId,
            [typeof(StatusCode)] = VariantType.StatusCode,
            [typeof(QualifiedName)] = VariantType.QualifiedName,
            [typeof(LocalizedText)] = VariantType.LocalizedText,
            [typeof(ExtensionObject)] = VariantType.ExtensionObject,
            /*
            [typeof(DataValue)] = VariantType.DataValue,
            [typeof(Variant)] = VariantType.Variant,
            [typeof(DiagnosticInfo)] = VariantType.DiagnosticInfo,
            */
        };

        private static Dictionary<Type, VariantType> elemTypeMap = new Dictionary<Type, VariantType>()
        {
            [typeof(bool)] = VariantType.Boolean,
            [typeof(sbyte)] = VariantType.SByte,
            [typeof(byte)] = VariantType.Byte,
            [typeof(short)] = VariantType.Int16,
            [typeof(ushort)] = VariantType.UInt16,
            [typeof(int)] = VariantType.Int32,
            [typeof(uint)] = VariantType.UInt32,
            [typeof(long)] = VariantType.Int64,
            [typeof(ulong)] = VariantType.UInt64,
            [typeof(float)] = VariantType.Float,
            [typeof(double)] = VariantType.Double,
            [typeof(string)] = VariantType.String,
            [typeof(DateTime)] = VariantType.DateTime,
            [typeof(Guid)] = VariantType.Guid,
            [typeof(byte[])] = VariantType.ByteString,
            [typeof(XElement)] = VariantType.XmlElement,
            [typeof(NodeId)] = VariantType.NodeId,
            [typeof(ExpandedNodeId)] = VariantType.ExpandedNodeId,
            [typeof(StatusCode)] = VariantType.StatusCode,
            [typeof(QualifiedName)] = VariantType.QualifiedName,
            [typeof(LocalizedText)] = VariantType.LocalizedText,
            [typeof(ExtensionObject)] = VariantType.ExtensionObject,
            [typeof(Variant)] = VariantType.Variant,
            /*
            [typeof(DataValue)] = VariantType.DataValue,
            [typeof(DiagnosticInfo)] = VariantType.DiagnosticInfo,
            */
        };

        public Variant(object value)
        {
            if (value == null)
            {
                this.Value = null;
                this.Type = VariantType.Null;
                this.ArrayDimensions = null;
                return;
            }

            Type type = value.GetType();
            VariantType variantType;
            if (typeMap.TryGetValue(type, out variantType))
            {
                this.Value = value;
                this.Type = variantType;
                this.ArrayDimensions = null;
                return;
            }

            var encodable = value as IEncodable;
            if (encodable != null)
            {
                this.Value = new ExtensionObject(encodable);
                this.Type = VariantType.ExtensionObject;
                this.ArrayDimensions = null;
                return;
            }

            var array = value as Array;
            if (array != null)
            {
                Type elemType = value.GetType().GetElementType();
                if (elemType == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), elemType, "Array element Type is unsupported.");
                }

                if (elemTypeMap.TryGetValue(elemType, out variantType))
                {
                    this.Value = array;
                    this.Type = variantType;
                    this.ArrayDimensions = new int[array.Rank];
                    for (int i = 0; i < array.Rank; i++)
                    {
                        this.ArrayDimensions[i] = array.GetLength(i);
                    }

                    return;
                }

                if (elemType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IEncodable)))
                {
                    this.Value = array.Cast<IEncodable>().Select(v => new ExtensionObject(v)).ToArray();
                    this.Type = VariantType.ExtensionObject;
                    this.ArrayDimensions = new int[array.Rank];
                    for (int i = 0; i < array.Rank; i++)
                    {
                        this.ArrayDimensions[i] = array.GetLength(i);
                    }

                    return;
                }

                throw new ArgumentOutOfRangeException(nameof(value), elemType, "Array element Type is unsupported.");
            }

            throw new ArgumentOutOfRangeException(nameof(value), type, "Type is unsupported.");
        }

        public Variant(bool value)
        {
            this.Value = value;
            this.Type = VariantType.Boolean;
            this.ArrayDimensions = null;
        }

        public Variant(sbyte value)
        {
            this.Value = value;
            this.Type = VariantType.SByte;
            this.ArrayDimensions = null;
        }

        public Variant(byte value)
        {
            this.Value = value;
            this.Type = VariantType.Byte;
            this.ArrayDimensions = null;
        }

        public Variant(short value)
        {
            this.Value = value;
            this.Type = VariantType.Int16;
            this.ArrayDimensions = null;
        }

        public Variant(ushort value)
        {
            this.Value = value;
            this.Type = VariantType.UInt16;
            this.ArrayDimensions = null;
        }

        public Variant(int value)
        {
            this.Value = value;
            this.Type = VariantType.Int32;
            this.ArrayDimensions = null;
        }

        public Variant(uint value)
        {
            this.Value = value;
            this.Type = VariantType.UInt32;
            this.ArrayDimensions = null;
        }

        public Variant(long value)
        {
            this.Value = value;
            this.Type = VariantType.Int64;
            this.ArrayDimensions = null;
        }

        public Variant(ulong value)
        {
            this.Value = value;
            this.Type = VariantType.UInt64;
            this.ArrayDimensions = null;
        }

        public Variant(float value)
        {
            this.Value = value;
            this.Type = VariantType.Float;
            this.ArrayDimensions = null;
        }

        public Variant(double value)
        {
            this.Value = value;
            this.Type = VariantType.Double;
            this.ArrayDimensions = null;
        }

        public Variant(string value)
        {
            this.Value = value;
            this.Type = VariantType.String;
            this.ArrayDimensions = null;
        }

        public Variant(DateTime value)
        {
            this.Value = value;
            this.Type = VariantType.DateTime;
            this.ArrayDimensions = null;
        }

        public Variant(Guid value)
        {
            this.Value = value;
            this.Type = VariantType.Guid;
            this.ArrayDimensions = null;
        }

        public Variant(byte[] value)
        {
            this.Value = value;
            this.Type = VariantType.ByteString;
            this.ArrayDimensions = null;
        }

        public Variant(XElement value)
        {
            this.Value = value;
            this.Type = VariantType.XmlElement;
            this.ArrayDimensions = null;
        }

        public Variant(NodeId value)
        {
            this.Value = value;
            this.Type = VariantType.NodeId;
            this.ArrayDimensions = null;
        }

        public Variant(ExpandedNodeId value)
        {
            this.Value = value;
            this.Type = VariantType.ExpandedNodeId;
            this.ArrayDimensions = null;
        }

        public Variant(StatusCode value)
        {
            this.Value = value;
            this.Type = VariantType.StatusCode;
            this.ArrayDimensions = null;
        }

        public Variant(QualifiedName value)
        {
            this.Value = value;
            this.Type = VariantType.QualifiedName;
            this.ArrayDimensions = null;
        }

        public Variant(LocalizedText value)
        {
            this.Value = value;
            this.Type = VariantType.LocalizedText;
            this.ArrayDimensions = null;
        }

        public Variant(ExtensionObject value)
        {
            this.Value = value;
            this.Type = VariantType.ExtensionObject;
            this.ArrayDimensions = null;
        }

        public Variant(IEncodable value)
        {
            this.Value = new ExtensionObject(value);
            this.Type = VariantType.ExtensionObject;
            this.ArrayDimensions = null;
        }

        public Variant(Enum value)
        {
            this.Value = Convert.ToInt32(value, CultureInfo.InvariantCulture);
            this.Type = VariantType.Int32;
            this.ArrayDimensions = null;
        }

        public Variant(bool[] value)
        {
            this.Value = value;
            this.Type = VariantType.Boolean;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(sbyte[] value)
        {
            this.Value = value;
            this.Type = VariantType.SByte;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(short[] value)
        {
            this.Value = value;
            this.Type = VariantType.Int16;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(ushort[] value)
        {
            this.Value = value;
            this.Type = VariantType.UInt16;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(int[] value)
        {
            this.Value = value;
            this.Type = VariantType.Int32;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(uint[] value)
        {
            this.Value = value;
            this.Type = VariantType.UInt32;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(long[] value)
        {
            this.Value = value;
            this.Type = VariantType.Int64;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(ulong[] value)
        {
            this.Value = value;
            this.Type = VariantType.UInt64;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(float[] value)
        {
            this.Value = value;
            this.Type = VariantType.Float;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(double[] value)
        {
            this.Value = value;
            this.Type = VariantType.Double;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(string[] value)
        {
            this.Value = value;
            this.Type = VariantType.String;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(DateTime[] value)
        {
            this.Value = value;
            this.Type = VariantType.DateTime;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(Guid[] value)
        {
            this.Value = value;
            this.Type = VariantType.Guid;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(byte[][] value)
        {
            this.Value = value;
            this.Type = VariantType.ByteString;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(XElement[] value)
        {
            this.Value = value;
            this.Type = VariantType.XmlElement;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(NodeId[] value)
        {
            this.Value = value;
            this.Type = VariantType.NodeId;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(ExpandedNodeId[] value)
        {
            this.Value = value;
            this.Type = VariantType.ExpandedNodeId;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(StatusCode[] value)
        {
            this.Value = value;
            this.Type = VariantType.StatusCode;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(QualifiedName[] value)
        {
            this.Value = value;
            this.Type = VariantType.QualifiedName;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(LocalizedText[] value)
        {
            this.Value = value;
            this.Type = VariantType.LocalizedText;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(ExtensionObject[] value)
        {
            this.Value = value;
            this.Type = VariantType.ExtensionObject;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(Variant[] value)
        {
            this.Value = value;
            this.Type = VariantType.Variant;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(Enum[] value)
        {
            this.Value = value.Select(v => Convert.ToInt32(v, CultureInfo.InvariantCulture)).ToArray();
            this.Type = VariantType.Int32;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(IEncodable[] value)
        {
            this.Value = value.Select(v => new ExtensionObject(v)).ToArray();
            this.Type = VariantType.ExtensionObject;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public Variant(Array value)
        {
            this.Value = value;
            VariantType varType;
            Type elemType = value.GetType().GetElementType();
            if (elemType == null || !elemTypeMap.TryGetValue(elemType, out varType))
            {
                throw new ArgumentOutOfRangeException(nameof(value), elemType, "Array element type is unsupported.");
            }

            this.Type = varType;
            this.ArrayDimensions = new int[value.Rank];
            for (int i = 0; i < value.Rank; i++)
            {
                this.ArrayDimensions[i] = value.GetLength(i);
            }
        }

        public object Value { get; }

        public VariantType Type { get; }

        public int[] ArrayDimensions { get; }

        public static implicit operator Variant(bool value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(sbyte value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(byte value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(short value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ushort value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(int value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(uint value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(long value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ulong value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(float value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(double value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(string value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(DateTime value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(Guid value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(byte[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(XElement value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(NodeId value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ExpandedNodeId value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(StatusCode value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(QualifiedName value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(LocalizedText value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ExtensionObject value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(bool[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(sbyte[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(short[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ushort[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(int[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(uint[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(long[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ulong[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(float[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(double[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(string[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(DateTime[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(Guid[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(byte[][] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(XElement[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(NodeId[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ExpandedNodeId[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(StatusCode[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(QualifiedName[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(LocalizedText[] value)
        {
            return new Variant(value);
        }

        public static implicit operator Variant(ExtensionObject[] value)
        {
            return new Variant(value);
        }

        public static explicit operator bool(Variant value)
        {
            return (bool)value.Value;
        }

        public static explicit operator sbyte(Variant value)
        {
            return (sbyte)value.Value;
        }

        public static explicit operator byte(Variant value)
        {
            return (byte)value.Value;
        }

        public static explicit operator short(Variant value)
        {
            return (short)value.Value;
        }

        public static explicit operator ushort(Variant value)
        {
            return (ushort)value.Value;
        }

        public static explicit operator int(Variant value)
        {
            return (int)value.Value;
        }

        public static explicit operator uint(Variant value)
        {
            return (uint)value.Value;
        }

        public static explicit operator long(Variant value)
        {
            return (long)value.Value;
        }

        public static explicit operator ulong(Variant value)
        {
            return (ulong)value.Value;
        }

        public static explicit operator float(Variant value)
        {
            return (float)value.Value;
        }

        public static explicit operator double(Variant value)
        {
            return (double)value.Value;
        }

        public static explicit operator string(Variant value)
        {
            return (string)value.Value;
        }

        public static explicit operator DateTime(Variant value)
        {
            return (DateTime)value.Value;
        }

        public static explicit operator Guid(Variant value)
        {
            return (Guid)value.Value;
        }

        public static explicit operator byte[] (Variant value)
        {
            return (byte[])value.Value;
        }

        public static explicit operator XElement(Variant value)
        {
            return (XElement)value.Value;
        }

        public static explicit operator NodeId(Variant value)
        {
            return (NodeId)value.Value;
        }

        public static explicit operator ExpandedNodeId(Variant value)
        {
            return (ExpandedNodeId)value.Value;
        }

        public static explicit operator StatusCode(Variant value)
        {
            return (StatusCode)value.Value;
        }

        public static explicit operator QualifiedName(Variant value)
        {
            return (QualifiedName)value.Value;
        }

        public static explicit operator LocalizedText(Variant value)
        {
            return (LocalizedText)value.Value;
        }

        public static explicit operator ExtensionObject(Variant value)
        {
            return (ExtensionObject)value.Value;
        }

        public static explicit operator bool[] (Variant value)
        {
            return (bool[])value.Value;
        }

        public static explicit operator sbyte[] (Variant value)
        {
            return (sbyte[])value.Value;
        }

        public static explicit operator short[] (Variant value)
        {
            return (short[])value.Value;
        }

        public static explicit operator ushort[] (Variant value)
        {
            return (ushort[])value.Value;
        }

        public static explicit operator int[] (Variant value)
        {
            return (int[])value.Value;
        }

        public static explicit operator uint[] (Variant value)
        {
            return (uint[])value.Value;
        }

        public static explicit operator long[] (Variant value)
        {
            return (long[])value.Value;
        }

        public static explicit operator ulong[] (Variant value)
        {
            return (ulong[])value.Value;
        }

        public static explicit operator float[] (Variant value)
        {
            return (float[])value.Value;
        }

        public static explicit operator double[] (Variant value)
        {
            return (double[])value.Value;
        }

        public static explicit operator string[] (Variant value)
        {
            return (string[])value.Value;
        }

        public static explicit operator DateTime[] (Variant value)
        {
            return (DateTime[])value.Value;
        }

        public static explicit operator Guid[] (Variant value)
        {
            return (Guid[])value.Value;
        }

        public static explicit operator byte[][] (Variant value)
        {
            return (byte[][])value.Value;
        }

        public static explicit operator XElement[] (Variant value)
        {
            return (XElement[])value.Value;
        }

        public static explicit operator NodeId[] (Variant value)
        {
            return (NodeId[])value.Value;
        }

        public static explicit operator ExpandedNodeId[] (Variant value)
        {
            return (ExpandedNodeId[])value.Value;
        }

        public static explicit operator StatusCode[] (Variant value)
        {
            return (StatusCode[])value.Value;
        }

        public static explicit operator QualifiedName[] (Variant value)
        {
            return (QualifiedName[])value.Value;
        }

        public static explicit operator LocalizedText[] (Variant value)
        {
            return (LocalizedText[])value.Value;
        }

        public static explicit operator ExtensionObject[] (Variant value)
        {
            return (ExtensionObject[])value.Value;
        }

        public static bool IsNull(Variant a)
        {
            return (a.Type == VariantType.Null) || (a.Value == null);
        }

        public override string ToString()
        {
            return this.Value?.ToString() ?? "{null}";
        }
    }
}