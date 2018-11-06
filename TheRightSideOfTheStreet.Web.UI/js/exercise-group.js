'use strict';

module.exports = {

	exerciseGroups: function () {

		const $groups = $('.exercise-groups');
		if (!$groups) return;

		const pageKey = $groups.data('page-key');
		const controllerUrl = $groups.data('controller-url');

		$("[btn-category]").on("click", function () {

			const $this = $(this);
			var categoryKey = $this.data('category');

			if ($this.hasClass('select-btn-active')) {
				$this.removeClass('select-btn-active');
				categoryKey = null;
			}
			else {
				$('.workout-selection button').removeClass('select-btn-active');
				$this.addClass('select-btn-active');
			}

			$.get(controllerUrl, { pageKey: pageKey, page: 1, categoryKey: categoryKey }, function (response) {
				$groups.children('.children').remove();
				$groups.append(response);
			}, 'html');

		});

		$groups.on('click', '.pagination a', function () {

			const $this = $(this);
			const page = $this.data('page');

			var categoryKey;

			var $dugme = $("div.workout-selection button.select-btn-active");
			if (!$dugme) return;

			categoryKey = $dugme.data('category');
			
			if (!categoryKey) categoryKey = null;

			$.get(controllerUrl, { pageKey: pageKey, page: page, categoryKey: categoryKey }, function (response) {
				$groups.children('.children').remove();
				$groups.append(response);
			}, 'html');

		});
	},

	exerciseDetail: function () {

		$("[detail-step]").on("click", function () {

			const $this = $(this);
			const detailKey = $this.data('detail-key');
			const $detailKey = $("[data-detail-key=" + detailKey + "]");
			
			if (!$detailKey) return;
			$detailKey.siblings("[data-detail-key]").hide();
			$detailKey.show();
			
			if (!$this.hasClass('select-btn-active')) {
				$('.workout-picker button').removeClass('select-btn-active');
				$this.addClass('select-btn-active');
			}
		});
	},

	sendRequest: function () {

		$("[send-request]").on("click", function () {

			const settingsKey = $(this).data("settings-key");
			var controllerUrl = $(this).data("controller");

			$.post(controllerUrl, { settingsKey : settingsKey }, function (response) {
				$('.send-request button').remove();
				$('.send-request').append("<span>" + response + "</span>");
			}, 'html');
			
		});
	}
};