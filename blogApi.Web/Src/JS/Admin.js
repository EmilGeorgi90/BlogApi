$(document).ready(function() {
    var jsonData;
    var url;
    var postID;
    $('.nav-item').click(function(e) {
        event.preventDefault(e);
        $('.active').removeClass('active');
        $(this).addClass('active');
        var ajaxer = $(this).text();
        ajaxer = ajaxer.split(' ')[28] + ajaxer.split(' ')[29];
        $("section").remove();
        $("#sectionContainer").append($(document.createElement("section")).load(ajaxer + ".html", function(body, status, xhr) {
            if (status == 'success') {
                if (ajaxer.includes("Editpost")) {
                    if ($("#SelectPost > option").length < 2) {
                        $.getJSON("https://localhost:44321/api/posts", function(data, textStatus, jqxhr) {
                            if (textStatus == 'success') {
                                postdata = data;
                                $.each(data, function(index, valueOfElement) {
                                    $("#SelectPost").append($(document.createElement('option')).text(valueOfElement.postId).val(valueOfElement.postId));
                                });
                            }
                        });
                        $("#SelectPost").change(function(e) {
                            $.getJSON("https://localhost:44321/api/posts/" + $(this).val(), function(data, textStatus) {
                                if (textStatus == 'success') {
                                    $("#validationCustom01").val(data.title);
                                    $('#validationServer03').append($(document.createElement('option')).val(data.postingUser.name).text(data.postingUser.name));
                                    $('#validationServer03').val(data.postingUser.name);
                                    $('#validationServer02').text(data.content);
                                    $('#image-url-holder').text(data.imageUrl);
                                    postID = data.postId;
                                }
                            });
                        }).change();
                        $("#submitter").click(function(e) {
                            event.preventDefault(e);
                            var json = {
                                postId: postID,
                                title: $("#validationCustom01").val(),
                                content: $("#validationServer02").val(),
                                imageUrl: url,
                                dateOfPost: moment().format(),
                                postingUserID: jsonData.filter(word => word.name == $("#validationServer03").val())[0].userInfoID,
                                postingUser: null
                            };
                            console.log(json);
                            $.ajax({
                                method: "PUT",
                                url: "https://localhost:44321/api/Posts/" + postID,
                                data: JSON.stringify(json),
                                contentType: "application/json",
                                datatype: "json",
                            }).dont(location.reload());
                        });
                    }
                }
            }
        }));

        $.getJSON("https://localhost:44321/api/userinfoes",
            function(data, textStatus, jqXHR) {
                jsonData = data;
                if (textStatus == 'success') {
                    $.each(data, function(index, valueOfElement) {
                        $('#validationServer03').append($(document.createElement('option')).text(valueOfElement.name).val(valueOfElement.name));
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
});