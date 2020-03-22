using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WPSOnline.Web.Controllers
{
    /// <summary>
    /// WPSOnline在线预览与编辑
    /// </summary>
    public class WPSOnlineController : Controller
    {
        ///// <summary>
        ///// 报告在线预览编辑页面
        ///// </summary>
        ///// <param name="viewModel"></param>
        ///// <returns></returns>
        //public async Task<IActionResult> Index(ReportRequestViewModel viewModel)
        //{
        //    var reportListDto = await _reportAppService.GetReport(new EntityDto<Guid>(viewModel.ReportId.Value));
        //    return View(reportListDto);
        //}

        ///// <summary>
        ///// 获取在线编辑/预览文件信息
        ///// </summary>
        ///// <param name="viewModel"></param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[Route("v1/3rd/file/info")]
        //public async Task<JsonResult> GetReportFileInfo(WPSRequestViewModel viewModel)
        //{
        //    var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
        //    var userToken = HttpContext.Request.Headers["x-wps-weboffice-token"].ToString();
        //    var reportId = HttpContext.Request.Headers["x-weboffice-file-id"].ToString();

        //    var output = await _reportAppService.GetCurrentUserAndReportInfo(new GetCurrentUserAndReportInfoInput()
        //    {
        //        Signature = viewModel._w_signature,
        //        AppId = viewModel._w_appid,
        //        UserAgent = userAgent,
        //        UserToken = userToken,
        //        ReportId = reportId,
        //    });

        //    return Json(output);
        //}

        ///// <summary>
        ///// 报告下载
        ///// </summary>
        ///// <param name="viewModel"></param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //public async Task<IActionResult> DownLoadReport(EntityViewModel<Guid> viewModel)
        //{
        //    var input = ObjectMapper.Map<EntityDto<Guid>>(viewModel);
        //    var downLoadReportOutPut = await _reportAppService.DownLoadReportAsync(input);
        //    var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
        //    var memi = provider.Mappings[downLoadReportOutPut.ContentType];

        //    return File(downLoadReportOutPut.FileByte, memi, downLoadReportOutPut.FileName);
        //}

        ///// <summary>
        ///// 保存报告
        ///// </summary>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[Route("v1/3rd/file/save")]
        //[HttpPost]
        //public async Task<JsonResult> SaveReportFile(WPSRequestViewModel viewModel)
        //{
        //    var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
        //    var userToken = HttpContext.Request.Headers["x-wps-weboffice-token"].ToString();
        //    var reportId = HttpContext.Request.Headers["x-weboffice-file-id"].ToString();

        //    var file = Request.Form.Files.First();
        //    if (file == null)
        //    {
        //        throw new UserFriendlyException(L("File_Empty_Error"));
        //    }

        //    if (file.Length > 1048576 * 100) //100 MB
        //    {
        //        throw new UserFriendlyException(L("File_SizeLimit_Error"));
        //    }

        //    var output = await _reportAppService.SaveReportFileAsync(new SaveReportFileInput()
        //    {
        //        AppId = viewModel._w_appid,
        //        Signature = viewModel._w_signature,
        //        UserAgent = userAgent,
        //        UserToken = userToken,
        //        ReportId = reportId,
        //        FormFile = file
        //    });

        //    return Json(new { file = output });
        //}

        ///// <summary>
        ///// 获取当前编辑用户信息
        ///// </summary>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[Route("v1/3rd/user/info")]
        //[HttpPost]
        //public async Task<JsonResult> GetCurrentUserInfo([FromBody]WPSRequestViewModel viewModel)
        //{
        //    viewModel._w_appid = HttpContext.Request.Query["_w_appid"].ToString();
        //    viewModel._w_signature = HttpContext.Request.Query["_w_signature"].ToString();
        //    var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
        //    var userToken = HttpContext.Request.Headers["x-wps-weboffice-token"].ToString();
        //    var reportId = HttpContext.Request.Headers["x-weboffice-file-id"].ToString();

        //    var output = await _reportAppService.GetCurrentUserInfo(new GetCurrentUserInfoInput()
        //    {
        //        AppId = viewModel._w_appid,
        //        Signature = viewModel._w_signature,
        //        UserAgent = userAgent,
        //        UserToken = userToken,
        //        Ids = viewModel.Ids,
        //    });

        //    return Json(output);
        //}
    }
}
