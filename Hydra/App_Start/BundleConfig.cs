﻿using System.Web;
using System.Web.Optimization;

namespace Hydra
{
    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/mustache").Include(
                "~/Scripts/mustache.js"));


            bundles.Add(new ScriptBundle("~/bundles/customjs").Include(
                "~/Scripts/JS/Site.js"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(

                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/bootstrap-paper.css",
                "~/Content/site.css"));
        }
    }
}