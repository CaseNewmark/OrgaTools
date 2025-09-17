<script setup lang="ts">
import { ref } from 'vue'
import { VueFlow, useVueFlow } from '@vue-flow/core'
import { Controls, ControlButton } from '@vue-flow/controls'

const { onInit, onNodeDragStop, onConnect, addEdges, setViewport, toObject } = useVueFlow()

onInit((vueFlowInstance) => {
  // instance is the same as the return of `useVueFlow`
  vueFlowInstance.fitView()
})

function resetTransform() {
  setViewport({ x: 0, y: 0, zoom: 1 })
}

</script>

<template>
  <div class="mt-4 border-1 border-gray-200 bg-white rounded-md overflow-hidden h-90">
    <VueFlow class="h-full"
      :default-viewport="{ zoom: 1.5 }"
      :min-zoom="0.2"
      :max-zoom="4">
      <Controls position="top-left"
        :show-zoom="true"
        :show-fit-view="true"
        :show-interactive="false">
      </Controls>
    </VueFlow>
  </div>
</template>
