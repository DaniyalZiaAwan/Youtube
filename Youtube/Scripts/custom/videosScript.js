
const likeAndDislikeLink = $('.js-like, .js-dislike');

$(document).ready(() => {
    LikeAndDislike();
});

function LikeAndDislike() {

    likeAndDislikeLink.on('click', function (e) {

        var me = $(e.target);

        var data = {
            VideoId: me.attr('data-videoId'),
            Op: me.hasClass('js-like') ? 'like' : 'dislike',
            SecondOp: me.hasClass('likedAndDisliked') ? 'remove' : 'add'
        }

        $.ajax({
            url: '/api/videos/AddLikeAndDislike',
            type: 'POST',
            data: data,
            success: function () {
                me.toggleClass('likedAndDisliked');
                IncrementDecrementLikesDislikes(data, me);
            },
            error: function (error) {
                console.log(error);
            }
        });

    });
}

function IncrementDecrementLikesDislikes(data, me) {
    if (data.Op == 'like') {
        if (me.hasClass('likedAndDisliked')) {
            var likes = parseInt($('.likeCounts').text());
            likes++;
            $('.likeCounts').text(likes);
        }
        else {
            var likes = parseInt($('.likeCounts').text());
            likes--;
            $('.likeCounts').text(likes);
        }
    } else {
        if (me.hasClass('likedAndDisliked')) {
            var dislikes = parseInt($('.dislikeCounts').text());
            dislikes++;
            $('.dislikeCounts').text(dislikes);
        }
        else {
            var dislikes = parseInt($('.dislikeCounts').text());
            dislikes--;
            $('.dislikeCounts').text(dislikes);
        }
    }
}