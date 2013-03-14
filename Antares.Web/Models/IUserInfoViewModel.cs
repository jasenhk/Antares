using System;

namespace Antares.Web.Models
{
    public interface IUserInfoViewModel
    {
        string SharedFoo { get; set; }
        //UserInfo UserInfo { get; set; }
    }
}

/*
 * class IndexViewModel : IUserInfoViewModel
 * {
 *     string Message { get; set; }
 *     UserInfo UserInfo { get; set; }  // fulfills the IUserInfoViewModel contract
 * }
*/

/*
 * SharedDataView.cshtml
 * @model Antares.Web.Models.IUserInfoViewModel
 * <text>@Model.UserInfo.UserName</text>
*/

/*
 * Index.cshtml
 * @model Antares.Web.Models.IndexViewModel
 * <text>@Model.Message</text>
 * 
 * @Html.Partial("SharedDataView", Model)
*/