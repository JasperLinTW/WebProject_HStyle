<template>

    <header class="bg-opacity-0 targetAll sticky-top" id="myHeader">
    <router-link class="logo-style targetAll" to="/"><h1 class="trans1">H'STYLE</h1></router-link>
    </header>
    <nav class="navbar navbar-expand bg-ligt">
        <div Class="container-fluid" m-0 g-0 position-relative>
            <div class="nav inputGroup">
                <span class="icon ma-1 my-1 px-3">
                    <i class="fa-solid fa-magnifying-glass"></i>
                </span>
                <input class="fz14 py-1 ps-4 rounded-1 border-0" type="text" placeholder="" />
            </div>
            <div id="NavbarContent" class="nav">
                <ul class="navbar-nav">
                    <li class="nav-item dropdown">
                        <router-link to="/blog" class="nav-link text-dark px-3"><span class="targetAll">H'Blog</span></router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/recommend" class="nav-link text-dark px-3"><span class="targetAll">推薦商品</span></router-link>
                    </li>
                    <a href="#"></a>
                    <li class="nav-item dropdown">
                        <router-link to="/product" class="nav-link text-dark px-3"><span class="targetAll">新品上市</span></router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <router-link to="/product" class="nav-link text-dark px-3"><span class="targetAll">服飾名品</span></router-link>
                    </li>
                
                </ul>
            </div>

            <div class="nav justify-content-end ps-5">
                <div class="mx-3">
                    <a href="#" title="喜歡" class="text-dark"><i class="fa-regular fa-heart icon-hover fz-18"></i></a>
                </div>
                <div class="btn-light mx-3">
                    <a href="#" title="打卡" class="text-dark"><i class="fa-regular fa-circle-check  icon-hover fz-18"></i></a>
                </div>
                <div class="btn-light mx-3">
                    <a href="#" title="會員" class="text-dark"><i class="fa-regular fa-circle-user icon-hover fz-18"></i></a>
                </div>
                <div class="btn-light mx-3" >
                    <a href="#" title="購物車" class="text-dark"><i class="fa-solid fa-cart-shopping icon-hover fz-18"> </i></a>
                    
                </div>
            </div>
        </div>

    </nav>
    <Cart />
</template>
<script>
import Cart from './Cart.vue'
export default{
    components:{
        Cart,
    },
    mounted(){
         window.addEventListener("scroll",function(){
         var header = document.querySelector("header");
         header.classList.toggle("sticky", window.scrollY > 0);})   
    }
    
}


</script>
<style scoped>
.fz-18{
    font-size: 18px;
}
.icon-hover:hover{
    color: #46A3FF;
}

.logo-style{
    text-decoration: none;
    color: black;
}

.targetAll:hover{
    color: #46A3FF;
}

.nav-item::after{
 content: '';
  position: absolute;
  width: 100%;
  height: 3px;
  bottom: -3px;
  left: 0;
  background-color: #46A3FF;
  visibility: hidden;
  transform: scaleX(0);
  transition: all 0.3s ease-in-out 0s;

}

.nav-item:hover::after{
    visibility: visible;
  transform: scaleX(1);
}
</style>