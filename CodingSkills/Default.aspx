<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CodingSkills._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Coding Skill Challenge</h1>
        <p class="lead">This coding skill challenge is implemented with ASP.Net Web Forms. By clicking on the below button, a sample output will be generated based on the excel file created.</p>
        <p class="lead">Logs can be found at /log folder in the project directory.</p>
        <p class="lead">The below "Generate Result CSV" button will generate the output csv file.</p>
        <p> <asp:Button id="GenerateResult"
           Text="Generate Result CSV"
           OnClick="GenerateResult_Click" 
           runat="server"
           CssClass="btn btn-info btn-lg"/>
        </p>
    </div>

</asp:Content>
