using System;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
 
[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct SerializableBigInteger
{
    [FieldOffset(0)]
    public BigInteger BigInteger;
 
    [FieldOffset(0), SerializeField]
    RawBigInteger raw;
 
    [Serializable]
    struct RawBigInteger
    {
        public int Sign;
        public uint[] Bits;
    }

    public static implicit operator BigInteger(SerializableBigInteger i) => i.BigInteger;
    

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SerializableBigInteger))]
    class SerializableBigIntegerPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            string bstr;
            property = property.FindPropertyRelative(nameof(raw));
            var sign = property.FindPropertyRelative(nameof(RawBigInteger.Sign));
            var bits = property.FindPropertyRelative(nameof(RawBigInteger.Bits));
            var bint = new SerializableBigInteger
            {
                raw = new RawBigInteger
                {
                    Sign = sign.intValue,
                    Bits = GetBitsArray(bits)
                }
            };
 
            try
            {
                bstr = bint.BigInteger.ToString();
            }
            catch
            {
                bint.BigInteger = BigInteger.Zero;
                bstr            = bint.BigInteger.ToString();
            }
 
            bstr = EditorGUI.TextField(position, label, bstr);
 
            if (!BigInteger.TryParse(bstr, out bint.BigInteger))
                bint.BigInteger = BigInteger.Zero;
 
            sign.intValue = bint.raw.Sign;
            SetBitsArray(bits, bint.raw.Bits);
        }
 
        static void SetBitsArray(SerializedProperty property, uint[] array)
        {
            property.arraySize = array != null ? array.Length : 0;
 
            for (int i = 0; i < property.arraySize; i++)
                property.GetArrayElementAtIndex(i).intValue = unchecked((int)array[i]);
        }
 
        static uint[] GetBitsArray(SerializedProperty property)
        {
            if (property.arraySize == 0)
                return null;
 
            var array = new uint[property.arraySize];
 
            for (int i = 0; i < array.Length; i++)
                array[i] = unchecked((uint)property.GetArrayElementAtIndex(i).intValue);
 
            return array;
        }
    }
#endif
}