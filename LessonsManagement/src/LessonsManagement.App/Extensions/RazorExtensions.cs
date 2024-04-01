using System;
using LessonsManagement.App.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace LessonsManagement.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatStudentName(this RazorPage page, StudentViewModel studentName)
        {
            return studentName == null ? "-" : studentName.StudentName;
        }

    }
}