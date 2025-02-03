// Create Extension Method for ControllerBase     

using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Extensions
{
    public enum ResponseType
    {
        Create,
        Update,
        Delete,
        Get
    }

    public static class ControllerBaseExtension
    {
        /// <summary>
        /// Creates an appropriate ActionResult based on the response type and content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="controller">The controller instance.</param>
        /// <param name="response">The response object containing the result data.</param>
        /// <param name="responseType">The type of the response (Create, Update, Delete, Get).</param>
        /// <returns>An ActionResult containing the response data.</returns>
        public static ActionResult<BaseResponse<T>> CreateResponse<T>(this ControllerBase controller, BaseResponse<T> response, ResponseType responseType)
        {
            if (response.error != null)
            {
                if (response.message.ToString() == "Internal server error")
                {
                    return controller.StatusCode(500, response);
                }
                return controller.BadRequest(response);
            }
            switch (responseType)
            {
                case ResponseType.Create:
                    return controller.Created("api/todo", response);
                case ResponseType.Update:
                    return controller.Ok(response);
                case ResponseType.Delete:
                    return controller.NoContent();
                case ResponseType.Get:
                    if (response.results == null && response.results == null)
                    {
                        if (response.error != null)
                        {
                            return controller.NotFound(response);
                        }
                    }
                    return controller.Ok(response);
                default:
                    return controller.BadRequest(response);
            }
        }
    }
}