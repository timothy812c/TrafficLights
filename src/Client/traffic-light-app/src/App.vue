<template>
  <div id="app">
    <div class="grid-container">
      <!-- Create 3x3 grid items -->
      <div class="grid-item"></div>
      <div class="grid-item">
        <!-- 2 -->
        <TrafficLight :direction="0" :lights="lights" />
      </div>
      <div class="grid-item"></div>
      <div class="grid-item">
        <!-- 4 -->
        <TrafficLight :direction="2" :lights="lights" />
      </div>
      <div class="grid-item"></div>
      <div class="grid-item">
        <!-- 6 -->
        <TrafficLight :direction="3" :lights="lights" />
      </div>
      <div class="grid-item"></div>
      <div class="grid-item">
        <!-- 8 -->
        <TrafficLight :direction="1" :lights="lights" />
      </div>
      <div class="grid-item"></div>
    </div>
  </div>
</template>

<script>
import TrafficLight from './components/TrafficLight.vue';
import axios from 'axios';

export default {
  name: 'App',
  components: {
    TrafficLight,
  },
  data() {
    return {
      lights: [],
    };
  },
  mounted() {
    this.fetchTrafficLightData();
    setInterval(this.fetchTrafficLightData, 1000);
  },
  methods: {
    async fetchTrafficLightData() {
      try {
        const response = await axios.get('http://localhost:5019/api/trafficlights');
        this.lights = response.data;
      } catch (error) {
        console.error('Error fetching traffic light data:', error);
      }
    },
  },
};
</script>

<style>
#app {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}


* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

body {
  background: linear-gradient(#08f, #fff);
}

.grid-container {
  --line-color: gray;
  display: grid;
  grid-template-columns: repeat(3, 1fr); /* Create 3 columns */
  grid-template-rows: repeat(3, 1fr); /* Create 3 rows */
  width: 500px; /* Set the width to 500 pixels */
  height: 500px; /* Set the height to 500 pixels */
}

.grid-item:nth-child(4),
.grid-item:nth-child(8) {
  justify-content: flex-end;
}

.grid-item:nth-child(2),
.grid-item:nth-child(8){
  
  border-right: 5px solid var(--line-color);
  border-left: 5px solid var(--line-color);
}

.grid-item:nth-child(4),
.grid-item:nth-child(6){
  border-top: 5px solid var(--line-color);
  border-bottom: 5px solid var(--line-color);
}

.grid-item:nth-child(even),
.grid-item:nth-child(5) {
  background-color: #c5bebe;
}


.grid-item {
  display: flex;
  width: 100%;
  padding: 10px;
  /* border: 1px solid #ccc; */
  text-align: center;
  /* background-color: #f0f0f0; */
}

</style>
