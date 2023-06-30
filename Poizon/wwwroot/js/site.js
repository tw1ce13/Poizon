$(document).ready(function () {
    // Открытие формы регистрации
    $(".login-button").on("click", function () {
        $(".registration-overlay").fadeIn();
        $(".registration-form-container").css("right", "0");
    });

    // Закрытие формы регистрации
    $(".close-button").on("click", function () {
        $(".registration-overlay").fadeOut();
        $(".registration-form-container").css("right", "-400px");
    });

    // Открытие корзины
    $(document).ready(function () {
        $(".cart-link").on("click", function () {
            $(".cart-overlay").fadeIn();
        });

        $(".close-button").on("click", function () {
            $(".cart-overlay").fadeOut();
        });
    });
    $(".plus-btn").on("click", function () {
        var input = $(this).siblings("input");
        var currentValue = parseInt(input.val());
        input.val(currentValue + 1);
    });

    // Обработчик события для уменьшения количества товара
    $(".minus-btn").on("click", function () {
        var input = $(this).siblings("input");
        var currentValue = parseInt(input.val());
        if (currentValue > 1) {
            input.val(currentValue - 1);
        }
    });

});
// Обработчик события для увеличения количества товара


