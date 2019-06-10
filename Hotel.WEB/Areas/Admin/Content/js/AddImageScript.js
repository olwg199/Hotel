﻿$(function() {
    function readUrl(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function(e) {
                $("img#imgpreview")
                    .attr("src", e.target.result)
                    .width(200);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $("#imageUpload").change(function() {
        readUrl(this);
    });
})