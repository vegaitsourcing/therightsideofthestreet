'use strict';

module.exports = {

	subscribe: function () {

		$(".newsletter-submit").on("click", function () {
			
			const controllerUrl = $(this).data("controller-url");
			const emailAddress = $("div.newsletter-input-wrap input").val();
			if (!emailAddress) return;
	
			$.post(controllerUrl, { emailAddress: emailAddress }, function (response) {
				$('.newsletter-form .wrap').children().remove();
				$('.newsletter-form .wrap').append("<h2 class='centered color-white'>" + response + "</h2>");
			}, 'html');
			
		});

		$("[footer-submit]").on("click", function () {

			const controllerUrl = $(this).data("controller-url");
			const emailAddress = $("div.footer-subscribe input").val();

			if (!emailAddress) return;

			$.post(controllerUrl, { emailAddress: emailAddress }, function (response) {
				$('.newsletter .newsletter-form').children().remove();
				$('.newsletter .newsletter-form').append("<h1 class='h3'>" + response + "</h2>");
			}, 'html');

		});
	}
};