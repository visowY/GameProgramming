

## 渲染方面基本知识

* 1. 深度测试
* 2. 透明物体的渲染
    > 渲染队列
    > OverDraw 过度绘制问题


* 3.网格重建的执行顺序
    1. 合批部分的网格重建 rebatch
    2. Rebuild 针对单个UI物体的重新绘制。

* 4. 
> 避免使用自动排序组件 layout 尝试使用代码自己计算
> 避免使用GameObject 控制显示隐藏代码 SetActive

* 5. 重建部分的执行流程

* 6. UGUI合批规则描述

* 7. Mask不能合批
> Mask 会打断合批，切mask 自身会产生两个dw
> Mask 内部的自物体的合批不受影响。
> Mask 之间满足条件，Mask下的自物体满足合批条件

* 8. Rectmask2D


