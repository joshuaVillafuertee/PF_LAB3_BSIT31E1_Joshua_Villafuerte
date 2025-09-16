// wwwroot/js/site.js
$(function () {
    console.log("Greed Island site ready!");

    // Confirm before delete
    $("form[asp-action='DeleteConfirmed']").on("submit", function (e) {
        if (!confirm("Are you sure you want to delete this card?")) {
            e.preventDefault();
        }
    });
});
