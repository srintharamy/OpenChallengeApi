using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiContactChallenge.Api.Auth;
using WebApiContactChallenge.Api.Core;
using WebApiContactChallenge.Application.Interface.Base;
using WebApiContactChallenge.BusinessObject.Base;

namespace WebApiContactChallenge.Api.Controllers.Base
{
    public class ChallengeControllerBase<T> : ControllerBase
        where T : IBusinessObjectBase
    {
        protected IChallengeServiceBase<T> _service;

        private void SetUserConnected()
        {
            _service.UserConnected = Request.Headers[AuthenticationMiddleware.FakeAuthorization];
        }

        protected IResponseItem<TResult> CreateResponseItem<TResult>(
            Func<object> func,
            string message = null)
            where TResult : class
        {
            SetUserConnected();
            try
            {
                return new ResponseItem<TResult>
                {
                    RespStatus = eResponseStatus.Ok,
                    RespMessage = message,
                    Item = func() as TResult
                };
            }
            catch (Exception exc)
            {
                return ExceptionResponse<ResponseItem<TResult>>(exc);
            }
        }

        protected IResponseItems<TResult> CreateResponseItems<TResult>(
            Func<IEnumerable<object>> func,
            string message = null)
            where TResult : class
        {
            SetUserConnected();
            try
            {
                var responseItems = new ResponseItems<TResult>
                {
                    RespStatus = eResponseStatus.Ok,
                    RespMessage = message,
                    Items = func() as IEnumerable<TResult>
                };
                return responseItems;
            }
            catch (Exception exc)
            {
                return ExceptionResponse<ResponseItems<TResult>>(exc);
            }
        }

        protected T CreateResponse<T>(Func<T> function)
            where T : ResponseBase, new()
        {
            SetUserConnected();
            try
            {
                var response = function();
                return response;
            }
            catch (Exception exc)
            {
                return ExceptionResponse<T>(exc);
            }
        }

        private static TResult ExceptionResponse<TResult>(Exception e)
            where TResult : IResponseBase, new()
        {
            // TODO : Centralize all Api log here
            return new TResult { RespMessage = e.Message, RespStatus = eResponseStatus.Exception };
        }
    }
}