<template>
    <div>
        <div class="navContanier m-auto">
            <nav class="m-auto justify-between items-center py-1">
                <div class="logonav">
                    <a href="">
                        <img src="/src/assets/img/logo.png" alt="">
                    </a>
                </div>
                <ul>
                    <li class= "text-white">
                        <router-link to="/">Home</router-link>
                    </li>
                    <li class= "text-white">
                        <router-link to="/about">About</router-link>
                    </li>
                    <li class= "text-white">
                        <router-link to="/"></router-link>
                    </li>
                </ul>    
            </nav>
        </div>
        <router-view />
    </div>
</template>