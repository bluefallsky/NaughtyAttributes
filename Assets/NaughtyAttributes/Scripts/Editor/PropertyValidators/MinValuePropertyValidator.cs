﻿using UnityEditor;

namespace NaughtyAttributes.Editor
{
    [PropertyValidator(typeof(MinValueAttribute))]
    public class MinValuePropertyValidator : PropertyValidator
    {
        public override void ValidateProperty(SerializedProperty property)
        {
            MinValueAttribute minValueAttribute = PropertyUtility.GetAttributes<MinValueAttribute>(property)[0];

            if (property.propertyType == SerializedPropertyType.Float)
            {
                if (property.floatValue < minValueAttribute.MinValue)
                {
                    property.floatValue = minValueAttribute.MinValue;
                }
            }
            else if (property.propertyType == SerializedPropertyType.Integer)
            {
                if (property.intValue < minValueAttribute.MinValue)
                {
                    property.intValue = (int)minValueAttribute.MinValue;
                }
            }
            else
            {
                string warning = minValueAttribute.GetType().Name + " doesn't affect non-float or non-integer fields";
                EditorGUILayout.HelpBox(warning, MessageType.Warning);
                UnityEngine.Debug.LogWarning(warning);
            }
        }
    }
}