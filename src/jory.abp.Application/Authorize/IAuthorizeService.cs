using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using jory.abp.ToolKits.Base;

namespace jory.abp.Application.Authorize
{
    public interface IAuthorizeService
    {
        /// <summary>
        /// 获取登录地址(GitHub)
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> GetLoginAddressAsync();

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetAccessTokenAsync(string code);

        /// <summary>
        /// 登录成功，生成Token
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GenerateTokenAsync(string accessToken);
    }
}
