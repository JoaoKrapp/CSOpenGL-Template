#version 330 core

layout(location = 0) in vec3 aPos;

uniform vec2 offset;
uniform float aspectRatio;

void main()
{
    vec2 scaledPos = aPos.xy + offset; // Aplica deslocamento
    scaledPos.x /= aspectRatio;

    gl_Position = vec4(scaledPos, aPos.z, 1.0);
}
