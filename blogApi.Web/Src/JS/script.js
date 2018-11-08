$(document).ready(function() {
    $.getJSON("https://localhost:44321/api/Posts", function(data) {
        console.log(data);
        $(data).each(function(index, item) {
            $(".card-group").append(
                $(document.createElement('div')).addClass("card").addClass('col-12').append(
                    $(document.createElement('h5')).append($(document.createElement('strong')).text(item.title).addClass('card-title').addClass('pl-2').addClass('pt-2'))).append(
                    $(document.createElement('img')).attr("src", item.imageUrl).addClass('card-img-top')
                ).append(
                    $(document.createElement('small')).addClass('bg-blue').addClass('sectionTextDate').text(item.dateOfPost).addClass('pl-2').addClass('pt-2')
                )
                .append(
                    $(document.createElement('div')).addClass('card-body').append(
                        $(document.createElement('p')).text(item.content).addClass('card-text')
                    )
                ).append(
                    $(document.createElement('div')).addClass('card-footer').append(
                        $(document.createElement('small')).addClass('text-muted').text('by ' + item.postingUser.name)
                    )
                ).addClass('mb-4')
            );
        });
    });
    $('.nav-item').click(function(e) {
        event.preventDefault(e);
        $('.active').removeClass('active').addClass('place-holder');
        $(this).children('.place-holder ').addClass('active').removeClass('place-holder');
    });
});