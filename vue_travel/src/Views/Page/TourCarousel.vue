<template>
    <div class="container-fluid">
        <h2 class="carousel-title">Ưu đãi</h2>
        <div class="owl-carousel owl-theme">
            <div class="item">
                <a href="#">
                    <img src="../../assets/owl_carousel/bn_230403_TourHongKong_1024-768px.png" alt="Hong Kong">
                </a>
            </div>
            <div class="item">
                <a href="#">
                    <img src="../../assets/owl_carousel/bn_230403_HANQUOC-DAINHACHOI_1024-768px.png" alt="Dai hoi han quoc">
                </a>
            </div>
            <div class="item">
                <a href="#">
                    <img src="../../assets/owl_carousel/bn__230511_.png" alt="Dai hoi han quoc 4 ngay 3 dem">
                </a>
            </div>
            <div class="item">
                <a href="#">
                    <img src="../../assets/owl_carousel/bn__230510_.png" alt="Trai nghiem mua he nuoc uc">
                </a>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    mounted() {
        // eslint-disable-next-line no-undef
        $(document).ready(function () {
            // eslint-disable-next-line no-undef
            $(".owl-carousel").owlCarousel({
                center: true,
                loop: true,
                margin: 20,
                responsive: {
                    0: {
                        items: 2
                    },
                    600: {
                        items: 2
                    },
                    1000: {
                        items: 3
                    }
                },
                autoplay: true,
                autoplayTimeout: 4000,
                autoplayHoverPause: true
            });
        });
    },

}
</script>
<style>
.carousel-title {
    font-size: 3rem;
    color: #2d4271;
    font-weight: bold;
    margin-bottom: 2rem;
    padding:0 10px;
}
.owl-carousel {
    padding: 0 10px;
}

.owl-carousel .owl-item {
    border-radius: 10px;
    overflow: hidden;
}

.owl-carousel .owl-stage {
    transition: all 0.7s ease-in-out !important;
}
.owl-dots button span {
    background-color: rgb(0 100 182 / 25%) ;
}

.owl-theme .owl-dots .owl-dot.active span, .owl-theme .owl-dots .owl-dot:hover span {
    background-color: #2d4271 ;
}
</style>