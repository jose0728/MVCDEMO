using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDEMO.Models
{
    public class UserInfo
    {
        /// <summary>
        /// 员工在当前企业内的唯一标识，也称staffId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 企业Id
        /// </summary>
        public string EnterpriseId { get; set; }

        /// <summary>
        /// 用户类型：0企业员工 1外部联系人
        /// </summary>
        public short UserType { get; set; }

        /// <summary>
        /// 员工名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 职位信息
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 是否已经激活，true表示已激活，false表示未激活
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 头像url
        /// </summary>
        public string Avatar { get; set; }
    }
}