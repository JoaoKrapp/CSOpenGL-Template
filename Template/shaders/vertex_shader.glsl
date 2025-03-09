#version 330 core

layout(location = 0) in vec3 aPos;
out vec2 pos;

uniform vec2 offset;
uniform float aspectRatio;
uniform float uTime;

void main()
{
    vec3 position = aPos;

    position *= 0.5;

    // position.y += sin(uTime + position.x * 8)/8;

    position.xy += offset;
    position.x /= aspectRatio;

    
    gl_Position = vec4(position, 1.0);
    pos = position.xy;
}
