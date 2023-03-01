const routes = [
    { path: '/',name:'Home', component: ()=> import('../views/Home.vue') },
    { path: '/product',name:'Product', component:()=> import('../views/product.vue') },
    { path: '/recommend',name:'Recommend', component:()=> import('../views/Recommend.vue') },
    { path: '/blog',name:'Blog', component:()=> import('../views/Blog.vue') },
    { path: '/EssaysBlog',name:'EssaysBlog', component:()=> import('../views/EssaysBlog.vue') }
  ]
export default routes