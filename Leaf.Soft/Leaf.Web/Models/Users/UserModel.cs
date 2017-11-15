using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Leaf.Web.Models.Users
{
    public class UserModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [Display(Name="用户名称")]
        [Required(ErrorMessage ="{0}是必填项")]
        //[MinLength(2,ErrorMessage = "{0}的最小长度是{1}")]
        //[MaxLength(30, ErrorMessage = "{0}的最大长度是{1}")]
        [StringLength(10,MinimumLength =2,ErrorMessage = "{0}的长度应该不小于{2}, 不大于{1}")]
        public string Account { get; set; }
        //[Display(Name ="价格")]
        //[Range(0,double.MaxValue,ErrorMessage = "{0}的值必须大于{1}")]
        //public float Price { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int DelFlag { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastEditTime { get; set; }

        public string StatusName { get; set; }
        public string DelFlagName { get; set; }
    }
}
