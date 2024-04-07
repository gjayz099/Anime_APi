<script>
import { ref } from 'vue'

export default {
    setup() {
        const animeData = ref(null)

        async function animeGet() {
            try {
                const response = await fetch("http://localhost:5050/api/Anime")
                const data = await response.json()
                console.log(data)
                animeData.value = data
            } catch (error) {
                console.error("Error fetching anime:", error)
            }
        }
        animeGet()
        return { animeData }
    }
}
</script>

<template>
    <div>
        <div v-for="ane in animeData" :key="ane.Id">
            <h1>{{ ane.title }}</h1>
        </div>
    </div>
</template>
