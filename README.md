# DotnetAiSuite
Ai suite for dotnet

# 1 核心架构设计
## 1.1 模块化设计
   使用 接口 和 策略模式 来抽象各个 AI 提供商的实现。
   每个 AI 提供商的实现作为独立的模块，便于扩展和维护。
   核心组件包含公共的调用接口、异常处理、日志记录等功能。
## 1.2 通用 API 接口
   定义一个通用的接口 IAIService，所有提供商实现都需要继承此接口。
   通过这个接口，用户可以统一调用 AI 模型进行文本生成、对话等任务，而不需要关心底层提供商的具体实现。
## 1.3 支持多 AI 提供商
   针对每个 AI 提供商（如 ChatGPT、Claude、讯飞等）实现具体的服务类，比如 OpenAIService、ClaudeService 等。
   每个服务类负责处理特定提供商的 API 调用和结果解析。
## 1.4 配置管理
   使用配置文件（如 appsettings.json 或 Environment Variables）管理各个 AI 提供商的 API Key 和其他设置。
   提供一个统一的配置服务 AIConfiguration，让用户可以方便地配置和切换提供商。
## 1.5 日志和错误处理
   统一的日志模块，便于调试和记录请求/响应。
   处理异常（如 API 限制、网络错误等），并优雅地返回用户友好的提示。

# 2 项目目录结构
```text
AI-Suite
│
├── src
│   ├── AI.Core
│   │   ├── Interfaces
│   │   │   ├── IAIService.cs            // 通用服务接口
│   │   │   ├── IAuthentication.cs       // 授权接口
│   │   │   └── IAIModel.cs              // 支持的模型接口
│   │   │
│   │   ├── Models
│   │   │   ├── AIOptions.cs             // 通用 AI 选项
│   │   │   ├── AIResponse.cs            // 通用响应模型
│   │   │   └── ErrorHandling.cs         // 错误信息结构
│   │   │
│   │   ├── Services
│   │   │   └── BaseAIService.cs         // 抽象基类，定义通用逻辑
│   │   │
│   │   ├── Utils
│   │   │   ├── Logger.cs                // 日志工具类
│   │   │   ├── ConfigurationManager.cs  // 配置管理工具
│   │   │   └── HttpClientHelper.cs      // HTTP 请求封装
│   │   │
│   │   ├── AIConfiguration.cs           // 核心配置服务
│   │   └── AIManager.cs                 // 核心管理器，负责提供商的动态加载和切换
│   │
│   ├── AI.Providers                     // AI 提供商的实现
│   │   ├── OpenAI
│   │   │   ├── OpenAIService.cs         // OpenAI 的具体实现
│   │   │   └── Models
│   │   │       ├── OpenAIOptions.cs     // OpenAI 配置选项
│   │   │       └── OpenAIResponse.cs    // OpenAI 响应模型
│   │   │
│   │   ├── Claude
│   │   │   ├── ClaudeService.cs         // Claude 的具体实现
│   │   │   └── Models
│   │   │       ├── ClaudeOptions.cs     // Claude 配置选项
│   │   │       └── ClaudeResponse.cs    // Claude 响应模型
│   │   │
│   │   ├── Baidu
│   │   │   ├── BaiduService.cs          // 百度大模型的具体实现
│   │   │   └── Models
│   │   │       ├── BaiduOptions.cs      // 百度 API 配置选项
│   │   │       └── BaiduResponse.cs     // 百度响应模型
│   │   │
│   │   ├── Xunfei
│   │   │   ├── XunfeiService.cs         // 讯飞大模型的具体实现
│   │   │   └── Models
│   │   │       ├── XunfeiOptions.cs     // 讯飞配置选项
│   │   │       └── XunfeiResponse.cs    // 讯飞响应模型
│   │   │
│   │   └── LLama
│   │       ├── LLamaService.cs          // LLama 模型的具体实现
│   │       └── Models
│   │           ├── LLamaOptions.cs      // LLama 配置选项
│   │           └── LLamaResponse.cs     // LLama 响应模型
│   │
│   └── AI.Demo                           // 演示项目
│       ├── Program.cs                    // 演示如何使用 AI Suite
│       ├── appsettings.json              // 配置文件
│       └── Startup.cs                    // .NET 项目启动文件
│
├── tests
│   ├── AI.Core.Tests                     // 核心功能的单元测试
│   │   ├── AIManagerTests.cs             // AIManager 测试
│   │   └── LoggerTests.cs                // 日志测试
│   │
│   ├── AI.Providers.Tests                // AI 提供商的单元测试
│   │   ├── OpenAITests.cs                // 测试 OpenAI 实现
│   │   ├── ClaudeTests.cs                // 测试 Claude 实现
│   │   └── BaiduTests.cs                 // 测试百度实现
│   │
│   └── AI.IntegrationTests               // 整体集成测试
│
├── docs                                  // 项目文档
│   ├── README.md                         // 项目介绍
│   ├── API.md                            // API 使用文档
│   ├── CONTRIBUTING.md                   // 贡献指南
│   └── CHANGELOG.md                      // 更新日志
│
├── LICENSE                               // 开源许可证
├── .gitignore                            // Git 忽略文件
└── AI-Suite.sln                          // 解决方案文件

```
# 3 关键功能模块说明
## 3.1 AI.Core
   核心模块，定义通用接口和工具。
   提供 AIManager，用来管理不同的 AI 提供商。
   包含通用的日志、配置和错误处理功能。
## 3.2 AI.Providers
   每个提供商对应一个子模块，实现 IAIService 接口。
   模块内包含服务类（API 调用逻辑）和模型类（用来解析配置和响应）。
## 3.3 AI.Demo
   演示项目，用于展示如何使用 AI Suite 提供的功能。
   包括简单的命令行交互或 Web 应用演示。
## 3.4 Tests
   单元测试和集成测试，确保各模块的功能稳定可靠。

# 4 部署与使用
## 4.1 项目初始化

克隆项目到本地，使用 Visual Studio 或 VS Code 打开解决方案。
安装依赖库，如 Newtonsoft.Json、RestSharp 等。
## 4.2 配置 API Key

在 appsettings.json 中配置各个提供商的 API Key 和其他设置。
## 4.3 扩展新提供商

实现 IAIService 接口，并将新服务注册到 AIManager 中。
## 4.4 运行 Demo

运行 AI.Demo 项目，体验 AI Suite 的功能。
