#define PLUGIN_API __declspec(dllexport)

const float scaleMultipler = 0.5f;

struct V3 {
	float x, y, z;
};

extern "C" {
	V3 PLUGIN_API ChangeScale(V3 originalScale) {
		V3 newScale = originalScale;

		newScale.x *= scaleMultipler;
		newScale.y *= scaleMultipler;
		newScale.z *= scaleMultipler;

		return newScale;
	}
}