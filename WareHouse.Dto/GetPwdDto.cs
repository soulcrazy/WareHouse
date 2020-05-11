/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GetPwdDto.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-05 16:42:08
 */

namespace WareHouse.Dto
{
    public class GetPwdDto
    {
        public string Name { get; set; }

        public string OldPwd { get; set; }

        public string NewPwd { get; set; }
    }
}