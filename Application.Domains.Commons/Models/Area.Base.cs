using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using OBear.Domains;

namespace Applications.Domains.Commons.Models
{
    /// <summary>
    /// 地区
    /// </summary>
    public partial class Area : EntityBase<int>
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        [StringLength(10, ErrorMessage = "编码输入过长，不能超过10位")]
        public string Code { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        [Required(ErrorMessage = "地区名称不能为空")]
        [StringLength(200, ErrorMessage = "地区名称输入过长，不能超过200位")]
        public string Text { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [Required(ErrorMessage = "拼音简码不能为空")]
        [StringLength(200, ErrorMessage = "拼音简码输入过长，不能超过200位")]
        public string PinYin { get; set; }
        /// <summary>
        /// 全拼
        /// </summary>
        [StringLength(500, ErrorMessage = "全拼输入过长，不能超过500位")]
        public string FullPinYin { get; set; }
    }
}
