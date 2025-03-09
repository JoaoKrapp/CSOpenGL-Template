## Shader variable origin

|                | **Attribute** | **Uniform**  | **Varying**  |
|--------------|-------------|-------------|-------------|
| **Vertex**   | Read Only   | Read Only   | Read/Write  |
| **Fragment** | N.A        | Read Only   | Read Only   |
| **Set From** | CPU        | CPU         | Vertex      |
| **Changes**  | Per Vertex | Constant    | Per Fragment |
