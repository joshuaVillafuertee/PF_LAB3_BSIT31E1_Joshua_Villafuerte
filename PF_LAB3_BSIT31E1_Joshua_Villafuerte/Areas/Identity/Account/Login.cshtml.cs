﻿@page
@model PF_LAB3_BSIT31E1_Joshua_Villafuerte.Areas.Identity.Pages.Account.LoginModel
@{
    ViewData["Title"] = "Log in";
}

<h1>@ViewData["Title"]</h1>

<div class="row">
    <div class="col-md-4">
        <section>
            <form method="post">
                <h4>Use your account to log in.</h4>
                <hr />
                <div asp-validation-summary="ModelOnly" class="text-danger"></div>

                <div class="form-floating mb-3">
                    <input asp-for="Input.Email" class="form-control" autocomplete="username" aria-required="true" />
                    <label asp-for="Input.Email"></label>
                    <span asp-validation-for="Input.Email" class="text-danger"></span>
                </div>

                <div class="form-floating mb-3">
                    <input asp-for="Input.Password" class="form-control" autocomplete="current-password" aria-required="true" />
                    <label asp-for="Input.Password"></label>
                    <span asp-validation-for="Input.Password" class="text-danger"></span>
                </div>

                <div class="checkbox mb-3">
                    <label asp-for="Input.RememberMe" class="form-label">
                        <input asp-for="Input.RememberMe" />
                        @Html.DisplayNameFor(m => m.Input.RememberMe)
                    </label>
                </div>

                <button type="submit" class="w-100 btn btn-lg btn-primary">Log in</button>
            </form>
        </section>
    </div>
</div>
