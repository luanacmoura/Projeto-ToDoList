#pragma checksum "C:\Users\46863229870\Projeto_ToDoList\Views\Usuario\Cadastrar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94fa762e0d4ce14ccf418cdb8db0661e3ae2d857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Cadastrar), @"mvc.1.0.view", @"/Views/Usuario/Cadastrar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/Cadastrar.cshtml", typeof(AspNetCore.Views_Usuario_Cadastrar))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94fa762e0d4ce14ccf418cdb8db0661e3ae2d857", @"/Views/Usuario/Cadastrar.cshtml")]
    public class Views_Usuario_Cadastrar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\46863229870\Projeto_ToDoList\Views\Usuario\Cadastrar.cshtml"
  
    ViewBag.Title="Cadastro";
    Layout = "MasterPage";

#line default
#line hidden
            BeginContext(66, 909, true);
            WriteLiteral(@"
<section class=""quadrado"">
    <h1> Cadastro de Usuário </h1>

    <form action=""/Usuario/Cadastrar"" method=""POST"">
        <label> Nome:
            <input type=""text"" name=""nome"" placeholder=""Insira seu nome..."" required=true>
        </label>

        <label> Email:
            <input type=""email"" name=""email"" placeholder=""Insira um email válido..."" required=true>
        </label>

        <label> Senha:
            <input type=""password"" name=""senha"" required=true>
        </label>

        <label> Tipo:
            <select name=""tipo"" required=true>
                <option name=""usuario""> Usuario comum </option>
                <option name=""admin""> Administrador</option>
            </select>
        </label>

        <input type=""submit"" value=""Enviar"">
        <p> Já possui uma conta? </p> 
        <a href=""/Usuario/Login""> Entrar </a>
    </form>
</section>
");
            EndContext();
            BeginContext(976, 16, false);
#line 34 "C:\Users\46863229870\Projeto_ToDoList\Views\Usuario\Cadastrar.cshtml"
Write(ViewBag.Mensagem);

#line default
#line hidden
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
