//#region TypeWriter

function initialTypeWriter(strings) {

    let textTypist = document.getElementById("text-typist");
    let typewriter = new Typewriter(textTypist, {
        loop: true,
        autoStart: true,
        strings: strings
    });
}

//#endregion

$(document).ready(function () {

    //#region ProgressBar

    var progressBars = $('.progress-bar');

    if (progressBars.length > 0) {

        $(progressBars).each(function (index, value) {

            var percent = $(value).attr('aria-valuenow');

            //set progress percent:
            $(value).css('width', percent + '%');
        });
    }

    //#endregion

    //#region Lazyload

    $(".lazy").lazy();

    //#endregion

});