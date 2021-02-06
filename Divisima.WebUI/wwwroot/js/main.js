/* =================================
------------------------------------
	Divisima | eCommerce Template
	Version: 1.0
 ------------------------------------
 ====================================*/


'use strict';


$(window).on('load', function () {
	/*------------------
		Preloder
	--------------------*/
	$(".loader").fadeOut();
	$("#preloder").delay(400).fadeOut("slow");

	

});

(function ($) {
	/*------------------zoom
		Navigation
	--------------------*/



	/*------------------
		ScrollBar
	--------------------*/
	$(".cart-table-warp, .product-thumbs").niceScroll({
		cursorborder: "",
		cursorcolor: "#afafaf",
		boxzoom: false
	});


	/*------------------
		Category menu
	--------------------*/
	$('.category-menu > li').hover(function (e) {
		$(this).addClass('active');
		e.preventDefault();
	});
	$('.category-menu').mouseleave(function (e) {
		$('.category-menu li').removeClass('active');
		e.preventDefault();
	});


	/*------------------
		Background Set
	--------------------*/
	$('.set-bg').each(function () {
		var bg = $(this).data('setbg');
		$(this).css('background-image', 'url(' + bg + ')');
	});



	/*------------------
		Hero Slider
	--------------------*/
	var hero_s = $(".hero-slider");
	hero_s.owlCarousel({
		loop: true,
		margin: 0,
		nav: true,
		items: 1,
		dots: true,
		animateOut: 'fadeOut',
		animateIn: 'fadeIn',
		navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
		smartSpeed: 1200,
		autoHeight: false,
		autoplay: true,
		onInitialized: function () {
			var a = this.items().length;
			$("#snh-1").html("<span>1</span><span>" + a + "</span>");
		}
	}).on("changed.owl.carousel", function (a) {
		var b = --a.item.index, a = a.item.count;
		$("#snh-1").html("<span> " + (1 > b ? b + a : b > a ? b - a : b) + "</span><span>" + a + "</span>");

	});

	hero_s.append('<div class="slider-nav-warp"><div class="slider-nav"></div></div>');
	$(".hero-slider .owl-nav, .hero-slider .owl-dots").appendTo('.slider-nav');



	/*------------------
		Brands Slider
	--------------------*/
	$('.product-slider').owlCarousel({
		loop: true,
		nav: true,
		dots: false,
		margin: 30,
		autoplay: true,
		navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
		responsive: {
			0: {
				items: 1,
			},
			480: {
				items: 2,
			},
			768: {
				items: 3,
			},
			1200: {
				items: 4,
			}
		}
	});


	/*------------------
		Popular Services
	--------------------*/
	$('.popular-services-slider').owlCarousel({
		loop: true,
		dots: false,
		margin: 40,
		autoplay: true,
		nav: true,
		navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
		responsive: {
			0: {
				items: 1,
			},
			768: {
				items: 2,
			},
			991: {
				items: 3
			}
		}
	});


	/*------------------
		Accordions
	--------------------*/
	$('.panel-link').on('click', function (e) {
		$('.panel-link').removeClass('active');
		var $this = $(this);
		if (!$this.hasClass('active')) {
			$this.addClass('active');
		}
		e.preventDefault();
	});


	/*-------------------
		Range Slider
	--------------------- */
	var rangeSlider = $(".price-range"),
		minamount = $("#minamount"),
		maxamount = $("#maxamount"),
		minPrice = rangeSlider.data('min'),
		maxPrice = rangeSlider.data('max');
	rangeSlider.slider({
		range: true,
		min: minPrice,
		max: maxPrice,
		values: [minPrice, maxPrice],
		slide: function (event, ui) {
			minamount.val('$' + ui.values[0]);
			maxamount.val('$' + ui.values[1]);
		}
	});
	minamount.val('$' + rangeSlider.slider("values", 0));
	maxamount.val('$' + rangeSlider.slider("values", 1));


	/*-------------------
		Quantity change
	--------------------- */
	var proQty = $('.pro-qty');
	proQty.prepend('<span class="dec qtybtn">-</span>');
	proQty.append('<span class="inc qtybtn">+</span>');
	proQty.on('click', '.qtybtn', function () {
		var $button = $(this);
		var oldValue = $button.parent().find('input').val();
		if ($button.hasClass('inc')) {
			var newVal = parseFloat(oldValue) + 1;
		} else {
			// Don't allow decrementing below zero
			if (oldValue > 0) {
				var newVal = parseFloat(oldValue) - 1;
			} else {
				newVal = 0;
			}
		}
		$button.parent().find('input').val(newVal);
	});



	/*------------------
		Single Product
	--------------------*/
	$('.product-thumbs-track > .pt').on('click', function () {
		$('.product-thumbs-track .pt').removeClass('active');
		$(this).addClass('active');
		var imgurl = $(this).data('imgbigurl');
		var bigImg = $('.product-big-img').attr('src');
		if (imgurl != bigImg) {
			$('.product-big-img').attr({ src: imgurl });
			$('.zoomImg').attr({ src: imgurl });
		}
	});


	//Get Shopping Cart
	getCartQuantity();


})(jQuery);
function getCareDetail(par) {
	if (!$(".careDetailContent p").length) {
		$.ajax({
			type: "Get",//Post
			url: "/bilgi",
			data: { "filter": par },
			success: function (data) {
				$(".careDetailContent").append("<p>" + data + "</p>");//append prepend after before
			},
			error: function (err) {
				alert(err.status)
			}
		});
	}
}
function getCargoDetail() {
	if (!$(".cargoDetailContent .cities option").length) {
		$.ajax({
			type: "Get",
			url: "/sehirler",
			success: function (data) {
				$.each(data, function (index, value) {
					$(".cities").append("<option value='" + value.id + "'>" + value.name + "</option>");
				});
				$(".cities").change(function () {
					getDistrict($(this).val())
				});
			},
			error: function (err) {
				alert(err.status)
			}
		});
	}
}
function getDistrict(cityID) {
	$(".districts").empty();
	$.ajax({
		type: "Get",
		url: "/ilceler",
		data: { "cityID": cityID },
		success: function (data) {
			$.each(data, function (index, value) {
				$(".districts").append("<option value='" + value.id + "'>" + value.name + "</option>");
			});
		},
		error: function (err) {
			alert(err.status)
		}
	});
}

function getCartQuantity() {
	$.ajax({
		type: "Get",
		url: "/urun/sepetMiktar",
		
		success: function (data) {
			$(".up-item span").text(data);
		},
		error: function (err) {
			alert(err.status)
		}
	});
}

function addCart(id, resim, miktar) {
	$.ajax({
		type: "Post",
		url: "/urun/sepeteekle",
		data: { "id": id, "picture": resim, "quantity": miktar },
		success: function (data) {
			getCartQuantity();
			$("#cartModal .modal-title").text("�r�n Sepete Eklendi");
			$("#cartModal .modal-body").text('<strong>'+data+' �r�n� Sepette</strong>');
			$("#cartModal").modal("show");
			setTimeout(function () {
				CartCloseModal()
			}, 2000);
		},
		error: function (err) {
			alert(err.status)
		}
	});
}

function CartCloseModal() {
	$("#cartModal").modal("hide");
}