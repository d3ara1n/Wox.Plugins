# GuidGen
可以生成一串Guid。

## Installation|安装
```
wpm install guidgen
```

## Usage|用法

 - `guid`：生成一串guid
   - 结果：`021f4f06-1e59-415a-b8e2-5f8f2fbf1aea`

 - `guid -h`：查看帮助
   - 结果：看截图

 - `guid -g`：刷新已有的guid字符串
   - 结果：`dc2defe7-2870-48eb-b150-fa7fd6616265`

 - `guid -n`：去掉'-'字符
   - 结果：`021f4f061e59415ab8e25f8f2fbf1aea`

 - `guid -u`：切换大写
   - 结果：`021F4F06-1E59-415A-B8E2-5F8F2FBF1AEA`

 - `guid -l`：切换小写
   - 结果：`021f4f06-1e59-415a-b8e2-5f8f2fbf1aea`

 - `guid -b`：花括号包裹
   - 结果：`{021f4f06-1e59-415a-b8e2-5f8f2fbf1aea}`

 - `guid -b1`：小括号包裹
   - 结果：`(021f4f06-1e59-415a-b8e2-5f8f2fbf1aea)`

 - `guid -b2`：中括号包裹
   - 结果：`[021f4f06-1e59-415a-b8e2-5f8f2fbf1aea]`

 - `guid -g -l -u -b -b1 -b2`：混合用法
   - 结果：`[({DC2DEFE7287048EBB150FA7FD6616265})]`


## Screenshots|屏幕截图

![Screentshot](https://github.com/ac682/Wox.Plugins/blob/master/GuidGen/screenshot.png?raw=true)
