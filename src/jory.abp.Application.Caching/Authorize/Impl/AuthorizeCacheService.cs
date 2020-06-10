using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using jory.abp.Domain.Shared;
using jory.abp.ToolKits.Base;
using jory.abp.ToolKits.Extensions;

namespace jory.abp.Application.Caching.Authorize.Impl
{
    public class AuthorizeCacheService : CachingServiceBase, IAuthorizeCacheService
    {
        private const string KeyGetLoginAddress = "Authorize:GetLoginAddress";

        private const string KeyGetAccessToken = "Authorize:GetAccessToken-{0}";

        private const string KeyGenerateToken = "Authorize:GenerateToken-{0}";

        /// <summary>
        /// 获取登录地址(GitHub)
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetLoginAddressAsync(Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyGetLoginAddress, factory, CacheStrategy.NEVER);
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetAccessTokenAsync(string code, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyGetAccessToken.FormatWith(code), factory, CacheStrategy.FIVE_MINUTES);
        }

        /// <summary>
        /// 登录成功，生成Token
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GenerateTokenAsync(string accessToken, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyGenerateToken.FormatWith(accessToken), factory, CacheStrategy.ONE_HOURS);
        }
    }
}
