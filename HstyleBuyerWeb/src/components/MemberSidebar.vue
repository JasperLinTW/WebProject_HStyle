<template>
    <div>

    </div>
    <div class="sidebar">
        <ul class="list-unstyled">
            <li>
                <router-link to="/account/MemberProfile" class="text-decoration-none text-dark">會員資料</router-link>
            </li>
            <li>
                <router-link to="/account/MemberAddresses" class="text-decoration-none text-dark">常用收件</router-link>
            </li>
            <li>
                <router-link to="/account/orders" class="text-decoration-none text-dark">訂單查詢</router-link>
            </li>
            <li>
                <router-link to="/account/MemberCollection" class="text-decoration-none text-dark">收藏清單</router-link>
            </li>
        </ul>
    </div>
</template>
  
<script>
</script>
  
<style scoped>
.sidebar {
    background-color: #f5f5f5;
    padding: 10px;
    height: 100%;
    width: 300px;
    min-height: 650px;
}

ul {
    margin: 0;
    padding: 0;
}

li {
    margin-bottom: 10px;
}

i {
    font-size: 1.2rem;
}
</style>
  