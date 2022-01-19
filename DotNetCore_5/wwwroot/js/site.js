// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('.datetimepicker').datetimepicker({ format: 'L' })
    $('.imageChange').change(function () {
        var input = this;
        if (input.files) {
            var rdr = new FileReader();
            rdr.onload = function (e) {
                $('.changeEdit').attr('src', e.target.result);
            }
            rdr.readAsDataURL(input.files[0]);
        }
    })
});