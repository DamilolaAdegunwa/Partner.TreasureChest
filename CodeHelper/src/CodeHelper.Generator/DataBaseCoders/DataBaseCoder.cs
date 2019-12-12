using CodeHelper.Generator.Utils;
using RazorEngine;
using RazorEngine.Templating; // For extension methods.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeHelper.Generator.DataBaseCoders
{
    /// <summary>
    /// 数据库解析器
    /// </summary>
    public class DataBaseCoder
    {
        public string RazorEditDto { get; set; }
        public string RazorListDto { get; set; }
        public string CreateOrUpdateRazorInput { get; set; }
        public string GetPagedRazorInput { get; set; }
        public string GetRazorForEditOutput { get; set; }
        public string IRazorAppService { get; set; }
        public string RazorAppService { get; set; }
        public string RazorController { get; set; }
        public string GetPagedRazorViewModel { get; set; }
        public string RazorRequestViewModel { get; set; }
        public string CreateOrUpdateRazorView { get; set; }
        public string RazorView { get; set; }

        public DataBaseCoder()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorListDto.txt");
            RazorListDto = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorEditDto.txt");
            RazorEditDto = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "CreateOrUpdateRazorInput.txt");
            CreateOrUpdateRazorInput = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "GetPagedRazorInput.txt");
            GetPagedRazorInput = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "GetRazorForEditOutput.txt");
            GetRazorForEditOutput = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorAppService.txt");
            RazorAppService = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "IRazorAppService.txt");
            IRazorAppService = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorController.txt");
            RazorController = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "GetPagedRazorViewModel.txt");
            GetPagedRazorViewModel = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorRequestViewModel.txt");
            RazorRequestViewModel = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorView.txt");
            RazorView = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "CreateOrUpdateRazorView.txt");
            CreateOrUpdateRazorView = File.ReadAllText(filePath);
        }

        public string RazorParse(TemplateParseModel templateParseModel)
        {
            var applicationPath = string.Format($"CodeResult\\{templateParseModel.EntityName}s\\Application\\{templateParseModel.EntityName}s");
            var mvcPath = string.Format($"CodeResult\\{templateParseModel.EntityName}s\\Mvc");
            StringBuilder builder = new StringBuilder();

            #region 数据传输对象
            var razorListDto = Engine.Razor.RunCompile(RazorListDto, nameof(RazorListDto), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"Dto\\{templateParseModel.EntityName}ListDto.cs"), razorListDto);
            builder.Append(razorListDto);

            var razorEditDto = Engine.Razor.RunCompile(RazorEditDto, nameof(RazorEditDto), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"Dto\\{templateParseModel.EntityName}EditDto.cs"), razorEditDto);
            builder.Append(razorEditDto);

            var createOrUpdateRazorInput = Engine.Razor.RunCompile(CreateOrUpdateRazorInput, nameof(CreateOrUpdateRazorInput), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"Dto\\CreateOrUpdate{templateParseModel.EntityName}Input.cs"), createOrUpdateRazorInput);
            builder.Append(createOrUpdateRazorInput);

            var getPagedRazorInput = Engine.Razor.RunCompile(GetPagedRazorInput, nameof(GetPagedRazorInput), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"Dto\\GetPaged{templateParseModel.EntityName}Input.cs"), getPagedRazorInput);
            builder.Append(getPagedRazorInput);

            var getRazorForEditOutput = Engine.Razor.RunCompile(GetRazorForEditOutput, nameof(GetRazorForEditOutput), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"Dto\\Get{templateParseModel.EntityName}ForEditOutput.cs"), getRazorForEditOutput);
            builder.Append(getRazorForEditOutput);
            #endregion

            #region 应用服务接口
            var iRazorAppService = Engine.Razor.RunCompile(IRazorAppService, nameof(IRazorAppService), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"I{templateParseModel.EntityName}AppService.cs"), iRazorAppService);
            builder.Append(iRazorAppService);
            #endregion

            #region 应用服务实现
            var razorAppService = Engine.Razor.RunCompile(RazorAppService, nameof(RazorAppService), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"{templateParseModel.EntityName}AppService.cs"), razorAppService);
            builder.Append(razorAppService);
            #endregion

            #region 控制器
            var razorController = Engine.Razor.RunCompile(RazorController, nameof(RazorController), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mvcPath, $"Controllers\\{templateParseModel.EntityName}Controller.cs"), razorController);
            builder.Append(razorController);
            #endregion

            #region 视图模型
            var getPagedRazorViewModel = Engine.Razor.RunCompile(GetPagedRazorViewModel, nameof(GetPagedRazorViewModel), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mvcPath, $"Models\\{templateParseModel.EntityName}s\\GetPaged{templateParseModel.EntityName}ViewModel.cs"), getPagedRazorViewModel);
            builder.Append(getPagedRazorViewModel);

            var razorRequestViewModel = Engine.Razor.RunCompile(RazorRequestViewModel, nameof(RazorRequestViewModel), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mvcPath, $"Models\\{templateParseModel.EntityName}s\\{templateParseModel.EntityName}RequestViewModel.cs"), razorRequestViewModel);
            builder.Append(razorRequestViewModel);
            #endregion

            #region 视图
            var razorView = Engine.Razor.RunCompile(RazorView, nameof(RazorView), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mvcPath, $"Views\\{templateParseModel.EntityName}\\Index.cshtml"), razorView);
            builder.Append(razorView);

            var createOrUpdateRazorView = Engine.Razor.RunCompile(CreateOrUpdateRazorView, nameof(CreateOrUpdateRazorView), typeof(TemplateParseModel), templateParseModel);
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mvcPath, $"Views\\{templateParseModel.EntityName}\\CreateOrUpdate{templateParseModel.EntityName}View.cshtml"), createOrUpdateRazorView);
            builder.Append(createOrUpdateRazorView);
            #endregion

            return builder.ToString();
        }
    }
}
