'use strict';

module.exports = {

    changeImage: function () {

        var $buttonSum = $('.membership-level button.btn-small').lenght;


        $($("img[src='" + $(".membership-level button.btn-small:eq(0)").data("image") + "']")[0]).parent().show() &&
            $($("img[src='" + $(".membership-level button.btn-small:eq(1)").data("image") + "']")[1]).parent().hide() &&
            $($("img[src='" + $(".membership-level button.btn-small:eq(2)").data("image") + "']")[2]).parent().hide();

    }
};