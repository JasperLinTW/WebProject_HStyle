<template>
    <footer>
        <div class="container-fluid pt-5">
            <div class="d-flex justify-content-evenly">
                <div class="col-lg-2">
                    <div class="text-white pb-2">部落格</div>
                    <router-link to="/blog" class="nav-link text-secondary"><span class="txt-hover">文章</span></router-link>
                    <router-link to="/blog" class="nav-link text-secondary"><span class="txt-hover">影片</span></router-link>
                </div>
                <div class="col-lg-2">
                    <span class="text-white">會員中心</span>
                </div>
                <div class="col-lg-2">
                    <span class="nav-link text-white">會員權益</span>
                </div>
                <div class="col-lg-2">
                    <div class="nav-link text-white pb-2">售後服務</div>
                    <router-link to="/" class="nav-link text-secondary"><span class="txt-hover">常見問題</span></router-link>
                </div>
            </div>
        </div>
    </footer>
    <Back2Top></Back2Top>
</template>

<script>
import Back2Top from "./Back2Top.vue"
export default {
    components: {
        Back2Top
    },
    data() {
        return {
            // 在這裡添加您的數據
        };
    },
    methods: {
        // 在這裡添加您的方法
    },
    mounted() {
        // 在這裡添加組件初始化邏輯
    }
};
</script>

<style scoped>
footer {
    height: 250px;
    background-color: black;
    position: relative;
    clear: both;
}

.txt-hover:hover {

    color: rgb(116, 129, 143);
}
</style>
