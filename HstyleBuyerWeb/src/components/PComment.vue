<template>
    <div class="card border-0 border-bottom pb-3 mb-3">
        <div class="row g-0">
            <div class="col-md-1"></div>
            <div class="col-md-4">
                <div class="row text-start">
                    <div class="col-md-2 mb-4">ac***t</div>
                    <div class="col-md-4 star-rating"><i v-for="(star, index) in 5" class="fa-solid fa-star"></i></div>
                    <div class="fz-comment col-md-12">讚讚</div>
                    <div class="col-md-12 my-2"></div>
                    <div class="col-md-6 mt-4"> 購買規格: Size: L | Color: 白 </div>
                    <div class="col-md-6 mt-4"> 2023-02-21 12:46:52 </div>
                </div>
            </div>
            <div class="col-md-3"></div>
            <div class="col-md-3 text-end">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-indicators">
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0"
                            class="active" aria-current="true" aria-label="Slide 1"></button>
                    </div>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="../assets/image/chanel1.jpg" class="d-block img-fluid rounded-start " alt="...">
                        </div>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators"
                        data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators"
                        data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>
            <div class="col-md-1 text-end ">
                <i class="fa-regular fa-thumbs-up fz-icon"><span class="fz-6 ps-2">有幫助</span></i>
            </div>
        </div>
    </div>
</template>
<script setup>
import { onMounted, ref } from 'vue';

const starClass = (index) => {
    if (index < selectedRating.value) {
        return 'fa-solid fa-star';
    } else {
        return 'fa-regular fa-star';
    }
}
</script>
<style scoped>
.fz-comment {
    font-size: 18px;
    height: 100%;
}

.fz-icon {
    font-size: 20px;
    cursor: pointer;
}

.fz-6 {
    font-size: 15px;
}

.card-text {
    font-size: 15px;
}

.card {
    width: 100%;
}

.star-rating i {
    font-size: 12pt;
    color: rgb(255, 208, 0);
    padding-top: 5px;
}
</style>