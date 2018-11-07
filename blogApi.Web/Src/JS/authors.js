$(document).ready(function(){
    $.getJSON("https://localhost:44321/api/Userinfoes/1/posts", function(data){
        console.log(data)
        $(data).each(function(index,item){
            $("body").append(
                $(document.createElement('img')).attr("src", item['postingUser']['profilPictureUrl']).addClass('imgAuthorPageBanner')
            ).append(
                $(document.createElement('img')).attr("src",item['imageUrl']).addClass('card-img-top')
            ).append(
                $(document.createElement('small')).addClass('bg-blue').addClass('sectionTextDate').text(item['dateOfPost']).addClass('pl-2').addClass('pt-2')
            ).append(
                $(document.createElement('div')).addClass('card-body')
                .append(
                    $(document.createElement('p')).text(item['content']).addClass('card-text')
                )
            ).append(
                $(document.createElement('div')).addClass('card-footer')
                .append(
                    $(document.createElement('small')).addClass('text-muted').text('by ' + item['postingUser']['name'])
            )).addClass('mb-4')
        })
    })
})