$(document).ready(function() {
    var jsonData;
    var url;
    $('.nav-item').click(function(e) {
        event.preventDefault(e);
        $('.active').removeClass('active');
        $(this).addClass('active');
        $("section").load("EditPost.html");
    });
    $.getJSON("https://localhost:44321/api/userinfoes",
        function(data, textStatus, jqXHR) {
            jsonData = data;
            console.log(data);
            if (textStatus == 'success') {
                $.each(data, function(indexInArray, valueOfElement) {
                    $('select').append($(document.createElement('option')).text(valueOfElement.name).val(valueOfElement.name));
                });
            } else {
                console.log(textStatus, jqXHR);
            }
        });
    $("#inputGroupFileAddon03").click(function() {
        url = prompt("Image url", "url here");
        $("#image-url-holder").text(url);
    });
    $("#submitter").click(function(e) {
        event.preventDefault(e);
        var json = {
            title: $("#validationCustom01").val(),
            content: $("#validationServer02").val(),
            imageUrl: url,
            dateOfPost: moment().format(),
            postingUserID: jsonData.filter(word => word.name == $("#validationServer03").val())[0].userInfoID,
            postingUser: null
        };
        console.log(json);
        $.ajax({
            method: "POST",
            url: "https://localhost:44321/api/Posts",
            data: JSON.stringify(json),
            contentType: "application/json",
            datatype: "json",
        });
    });
});