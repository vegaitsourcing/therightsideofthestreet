'use strict';

module.exports = {

    changeImage: function () {

        $("[membership-level-btn]").on("click", function () {
            const $this = $(this);
            const itemKey = $this.data("item");
            const $item = $("[data-item=" + itemKey + "]");

            if (!$item) return;
            $item.siblings("[data-item]").hide();
            $item.show();
        });
    }
};