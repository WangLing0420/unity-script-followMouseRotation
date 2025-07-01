using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRotation : MonoBehaviour
{
    void Update()
    {
        LookAtMouse();
    }

    void LookAtMouse()
    {
        // 获取鼠标在屏幕上的位置（单位：像素）
        Vector3 mousePosition = Input.mousePosition;
        
        // 将鼠标位置转换为屏幕比例（0到1）
        float normalizedX = Mathf.Clamp01(mousePosition.x / Screen.width);
        float normalizedY = Mathf.Clamp01(mousePosition.y / Screen.height);
        
        // 计算水平旋转角度：鼠标从左(0)到右(1)映射为90°到-90°
        float yaw = Mathf.Lerp(-90f, 90f, normalizedX);
        
        // 计算俯仰角度：鼠标从下(0)到上(1)映射为0°到90°
        float pitch = Mathf.Lerp(90f, 0f, normalizedY);
        
        // 创建旋转四元数（先水平旋转Yaw，再俯仰旋转Pitch）
        Quaternion targetRotation = 
            Quaternion.AngleAxis(yaw, Vector3.up) * // 绕世界Y轴旋转（水平）
            Quaternion.AngleAxis(pitch, Vector3.right); // 绕本地X轴旋转（俯仰）
        
        // 应用旋转到物体
        transform.rotation = targetRotation;
    }
}
