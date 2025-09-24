<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'
import type { Node } from '@vue-flow/core'
import { Panel, VueFlow, useVueFlow } from '@vue-flow/core'
import { Background } from '@vue-flow/background'
import { Controls, ControlButton } from '@vue-flow/controls'
import ProducerNode from '@/components/factory-game/ProducerNode.vue'
import ProcessorNode from '@/components/factory-game/ProcessorNode.vue'
import ConsumerNode from '@/components/factory-game/ConsumerNode.vue'
import type { FactoryNodeData } from '@/models/factory-game/FactoryNodeData'

import ContextMenu from 'primevue/contextmenu'
import type { ProducerNodeData } from '@/models/factory-game/ProducerNodeData'
import type { ProcessorNodeData } from '@/models/factory-game/ProcessorNodeData'
import type { ConsumerNodeData } from '@/models/factory-game/ConsumerNodeData'

const factoryGameContainer = ref<HTMLElement | null>(null)
const isFullWindow = ref(false)
const isFullscreen = ref(false)

const menu = ref()

const { onInit, onNodeDragStop, onConnect, addEdges, setViewport, toObject } = useVueFlow()

onInit((vueFlowInstance) => {
  // instance is the same as the return of `useVueFlow`
})

function resetTransform() {
  setViewport({ x: 0, y: 0, zoom: 1 })
}

const initialNodes = ref<Node<FactoryNodeData>[]>([
  {
    id: '1',
    type: 'producer',
    position: { x: 50, y: 50 },
    data: { name: 'Producer' }
  },
  {
    id: '2',
    type: 'processor',
    position: { x: 250, y: 50 },
    data: { name: 'Processor' }
  },
  {
    id: '3',
    type: 'consumer',
    position: { x: 450, y: 50 },
    data: { name: 'Consumer' }
  }
])

const { addNodes } = useVueFlow()

function generateRandomNode() {
  return {
    id: Math.random().toString(),
    position: { x: Math.random() * 500, y: Math.random() * 500 },
    label: 'Random Node',
    type: 'simple',
    data: { 
      hello: 'world',
    }
  }
}

function onAddNodes() {
  // add multiple nodes to the graph
  addNodes(Array.from({ length: 10 }, generateRandomNode))
}

function toggleFullscreen() {
  if (!document.fullscreenElement) {
    factoryGameContainer.value?.requestFullscreen()
  } else {
    document.exitFullscreen()
  }
}

function toggleFullWindow() {
  isFullWindow.value = !isFullWindow.value
}

function onFullscreenChange() {
  isFullscreen.value = !!document.fullscreenElement
}

onMounted(() => {
  document.addEventListener('fullscreenchange', onFullscreenChange)
})

onUnmounted(() => {
  document.removeEventListener('fullscreenchange', onFullscreenChange)
})

const onRightClick = (event: PointerEvent) => {
    menu.value.show(event);
};
</script>

<template>
  <div
    ref="factoryGameContainer"
    class="mt-4 border-1 border-gray-200 bg-white rounded-md overflow-hidden h-140"
    :class="{ 'full-window': isFullWindow }"
  >
    <VueFlow
      class="h-full"
      @contextmenu="onRightClick($event)"
      :nodes="initialNodes"
      :default-viewport="{ zoom: 1 }"
      :min-zoom="0.55"
      :max-zoom="3"
    >
      <Controls
        class="z-1000 bg-amber-400"
        position="top-left"
        :show-zoom="true"
        :show-fit-view="true"
        :show-interactive="false"
      >
        <ControlButton @click="resetTransform">1</ControlButton>
        <ControlButton @click="onAddNodes"><i class="pi pi-chart-scatter"></i></ControlButton>
        <ControlButton @click="toggleFullscreen"><i :class="isFullscreen ? 'pi pi-arrow-down-left-and-arrow-up-right-to-center' : 'pi pi-desktop'"></i></ControlButton>
        <ControlButton @click="toggleFullWindow"><i :class="isFullWindow ? 'pi pi-window-minimize' : 'pi pi-window-maximize'"></i></ControlButton>
      </Controls>
      <Background pattern-color="#aaa" :gap="16" />
      <template #node-producer="props">
        <ProducerNode :data="props.data" />
      </template>
      <template #node-processor="props">
        <ProcessorNode :data="props.data" />
      </template>
      <template #node-consumer="props">
        <ConsumerNode :data="props.data" />
      </template>
    </VueFlow>
    <ContextMenu :model="[
      { label: 'Add Node', icon: 'pi pi-plus', command: onAddNodes },
      { label: 'Reset View', icon: 'pi pi-refresh', command: resetTransform },
      { label: isFullscreen ? 'Exit Fullscreen' : 'Enter Fullscreen', icon: isFullscreen ? 'pi pi-arrow-down-left-and-arrow-up-right-to-center' : 'pi pi-desktop', command: toggleFullscreen },
      { label: isFullWindow ? 'Exit Full Window' : 'Enter Full Window', icon: isFullWindow ? 'pi pi-window-minimize' : 'pi pi-window-maximize', command: toggleFullWindow },
    ]" />
  </div>
</template>

<style scoped>
.full-window {
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  z-index: 100;
  margin-top: 0 !important;
  border-radius: 0 !important;
  height: 100% !important;
}
</style>
