<template>
    <header class="bg-opacity-0 targetAll sticky-top" id="myHeader">
    <h1 class="trans1">H'STYLE</h1>
    </header>
    <nav class="navbar navbar-expand bg-ligt">
        <div Class="container-fluid" m-0 g-0 position-relative>
            <div class="nav justify-content-center inputGroup">
                <span class="icon ma-1 my-1">
                    <i class="fa-solid fa-magnifying-glass"></i>
                </span>
                <input class="fz14 py-1 ps-4 rounded-1 border-0" type="text" placeholder="" />
            </div>
            <div id="NavbarContent" class="nav justify-content-center">
                <ul class="navbar-nav">
                    <li class="nav-item dropdown">
                        <router-link to="/blog" class="nav-link targetAll">H'Blog</router-link>
                        <!-- <a class="nav-link targetAll" href="#">H'Blog</a> -->
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/recommend" class="nav-link targetAll">推薦</router-link>
                        <!-- <a class="nav-link targetAll" href="#">推薦</a> -->
                    </li>
                    <a href="#"></a>
                    <li class="nav-item dropdown">
                        <router-link to="/product" class="nav-link targetAll">服飾名品</router-link>
                        <!-- <a class="nav-link targetAll" href="#">服飾名品</a> -->
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/" class="nav-link targetAll">香水</router-link>
                        <!-- <a class="nav-link targetAll" href="#">香水</a> -->
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/" class="nav-link targetAll">化妝品</router-link>
                        <!-- <a class="nav-link targetAll" href="#">化妝品</a> -->
                    </li>
                
                </ul>
            </div>

            

            <div class="nav justify-content-end">
                <div class="mx-3">
                    <a href="#" title="喜歡"><i class="fa-regular fa-heart text-bg-light"></i></a>
                </div>
                <div class="btn-light mx-3">
                    <a href="#" title="打卡"><i class="fa-regular fa-circle-check text-bg-light"></i></a>
                </div>
                <div class="btn-light mx-3">
                    <a href="#" title="會員"><i class="fa-regular fa-circle-user text-bg-light"></i></a>
                </div>
                <div class="btn-light mx-3" >
                    <a href="#" title="購物車" @click="showCart = true"><i class="fa-solid fa-cart-shopping text-bg-light"> <span class="badge">{{ cartItems }}</span></i></a>
                </div>
            </div>
        </div>

    </nav>
</template>
<script>
export default{
    mounted(){
        $(".target")
            .on("mouseenter", function () {
              $(".target").css("color", "#46A3FF");
            })
            .on("mouseleave", function () {
              $(".target").css("color", "black");
            });
    
          $(".targetAll")
            .on("mouseenter", function () {
              $(this).css("color", "#46A3FF");
            })
            .on("mouseleave", function () {
              $(this).css("color", "black");
            });
        // window.addEventListener("scroll",function(){
        //     var header = document.querySelector("header");
        //     header.classList.toggle("sticky", window.scrollY > 0);})
         
     
    }
    
}


</script>
<style></style>