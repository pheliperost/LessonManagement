$(document).ready(function () {
    $("#EventTypeId").on("change", function () {
        if ($("#EventTypeId option:selected").text() != "Lesson") {
            $("#groupStudentId").hide();
        } else {
            $("#groupStudentId").show();
        }
    });
});