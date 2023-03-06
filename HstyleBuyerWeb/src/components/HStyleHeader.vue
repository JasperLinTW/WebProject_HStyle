<template>
    <header class="bg-opacity-0 targetAll sticky-top" id="myHeader">
        <router-link class="logo-style targetAll" to="/">
            <h1 class="trans1">H'STYLE</h1>
        </router-link>
    </header>
    <nav class="navbar navbar-expand bg-ligt">
        <div Class="container-fluid" m-0 g-0 position-relative>
            <div class="nav inputGroup" id="app">
                <span class="icon ma-1 my-1 px-3">
                    <i class="fa-solid fa-magnifying-glass search targetAll"></i>
                </span>
                <input class="fz14 pb-1 ps-4 textbox" id="search" type="text" />
            </div>
            <div id="NavbarContent" class="nav">
                <ul class="navbar-nav">

                    <li class="nav-item dropdown">
                        <router-link to="/recommend" class="nav-link text-dark px-3"><span
                                class="targetAll">推薦商品</span></router-link>
                    </li>
                    <a href="#"></a>
                    <li class="nav-item dropdown">
                        <router-link to="/product" class="nav-link text-dark px-3"><span
                                class="targetAll">新品上市</span></router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/product" class="nav-link text-dark px-3"><span
                                class="targetAll">服飾名品</span></router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/EssaysBlog" class="nav-link targetAll">文章部落格</router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/blog" class="nav-link text-dark px-3"><span
                                class="targetAll">影片部落格</span></router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/member" class="nav-link targetAll">測試用會員</router-link>
                        <!-- <a class="nav-link targetAll" href="#">測試用會員</a> -->
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/MemberLogin" class="nav-link targetAll">測試用會員123</router-link>
                        <!-- <a class="nav-link targetAll" href="#">測試用會員</a> -->
                    </li>
                </ul>
            </div>

            <div class="nav justify-content-end ps-5">
                <div class="mx-3">
                    <a href="#" title="喜歡" class="text-dark"><i class="fa-regular fa-heart icon-hover fz-18"></i></a>
                </div>
                <div class="btn-light mx-3">
                    <a href="#" title="打卡" class="text-dark"><i class="fa-regular fa-circle-check  icon-hover fz-18"
                            data-bs-toggle="modal" data-bs-target="#checkInModal"></i></a>
                </div>
                <div class="btn-light mx-3">
                    <router-link to="/account/memberprofile" class="text-dark"><i
                            class="fa-regular fa-circle-user icon-hover"></i></router-link>
                </div>
                <div class="btn-light mx-3">
                    <a href="#" title="購物車" class="text-dark"><i class="fa-solid fa-cart-shopping icon-hover"
                            data-bs-toggle="modal" data-bs-target="#exampleModal"> </i></a>

                </div>
            </div>
        </div>
    </nav>
    <Cart />
    <CheckIn />
</template>
<script setup>
import Cart from './Cart.vue'
import CheckIn from './CheckIn.vue'
import { ref, onMounted } from "vue";

onMounted(() => {
    window.addEventListener("scroll", function () {
            var header = document.querySelector("header");
            header.classList.toggle("sticky", window.scrollY > 0)
                ;
        })

        document.querySelector(".search").addEventListener("click", function () {
            document.querySelector("#search").focus();
        });
});

</script>
<style scoped>
.search {
    cursor: pointer;
}

.fz-18 {
    font-size: 18px;
}

.icon-hover:hover {
    color: #46A3FF;
}

.logo-style {
    text-decoration: none;
    color: black;
}

.targetAll:hover {
    color: #46A3FF;
}

.nav-item::after {
    content: '';
    position: absolute;
    width: 100%;
    height: 2px;
    bottom: -2px;
    left: 0;
    background-color: #46A3FF;
    visibility: hidden;
    transform: scaleX(0);
    transition: all 0.3s ease-in-out 0s;

}

.nav-item:hover::after {
    visibility: visible;
    transform: scaleX(1);
}


.textbox {
    border: none;
    border-bottom: 1px solid transparent;
    outline: none;
    font-size: 16px;
    transition: border-bottom-color 0.5s ease-in-out;
}

.textbox:focus {
    border-bottom-color: #ced4da;
}

header {
    background-color: white;
    color: rgb(12, 13, 12);
    opacity: 0.9;
    /* 內距 */
    padding-top: 5px;
    padding-bottom: 5px;
    text-align: center;
}

header:hover {
    background-color: black;
    transition: 0.5s;
}

header.sticky {
    padding: 5px 100px;
    background: #fff;
}

header .sticky ul li a {
    color: #000;
}
</style>